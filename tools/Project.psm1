#Requires -Version 3.0

Set-StrictMode -Version Latest

Join-Path $PSScriptRoot 'Helpers.psm1' | Import-Module

# ------------------------------------------------------------------------------
# Private variables
# ------------------------------------------------------------------------------

[string] $script:RepositoryRoot = (Get-Item $PSScriptRoot).Parent.FullName

# ------------------------------------------------------------------------------
# Public methods
# ------------------------------------------------------------------------------

# .SYNOPSIS
# Get the last git commit hash.
#
# .PARAMETER Abbrev
# If present, finds the abbreviated commit hash.
#
# .OUTPUTS
# System.String. Get-GitCommitHash returns a string that contains the git commit hash.
# 
# .NOTES
# If the git command fails, returns an empty string.
function Get-GitCommitHash {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $false, Position = 0, ValueFromPipeline = $true)] $git,
        [switch] $abbrev
    )
    
    Write-Verbose 'Getting the last git commit hash.'
    
    $git = ?? $git { Get-Git }
    if ($git -eq $null) { return }

    if ($abbrev.IsPresent) {
        $fmt = '%h'
    } else {
        $fmt = '%H'
    }

    try {
        Write-Debug 'Call git.exe log.'
        $hash = . $git log -1 --format="$fmt"
    } catch {
        Write-Warning "Unabled to get the last git commit hash: $_"
        $hash = ''
    }

    $hash
}

# .SYNOPSIS
# Get the path to the PSake module.
#
# .PARAMETER NoVersion
# If present, do not include a version independent path.
#
# .OUTPUTS
# System.String. Get-PSakeModulePath returns a string that contains the path to the PSake module.
function Get-PSakeModulePath {
    [CmdletBinding()]
    param([switch] $noVersion)
    
    if ($noVersion.IsPresent) {
        Get-RepositoryPath 'packages\psake\tools\psake.psm1'
    } else {
        (gci (Get-RepositoryPath 'packages\psake.*\tools\psake.psm1') | select -First 1)
    }
}

# .SYNOPSIS
# Combine the repository path and several parts.
#
# .PARAMETER Parts
# Specifies the elements to append to the repository path.
#
# .OUTPUTS
# System.String. Get-RepositoryPath returns a string that contains the resulting path.
function Get-RepositoryPath {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true, Position = 0)] [string[]] $pathList
    )
    
    Join-Path -Path $script:RepositoryRoot -ChildPath (Join-PathList $pathList)
}

# .SYNOPSIS
# Return the path to the repository.
#
# .OUTPUTS
# System.String. Get-RepositoryRoot returns a string that contains the path
# to the repository.
function Get-RepositoryRoot {
    $script:RepositoryRoot
}

# .SYNOPSIS
# Install 7-Zip.
#
# .OUTPUTS
# System.String. Install-7Zip returns a string that contains the path to the 7-Zip executable.
function Install-7Zip {
    [CmdletBinding()]
    param()
    
    Write-Verbose 'Installing 7-Zip.'
    
    $sevenZip = Get-RepositoryPath 'tools', '7za.exe'

    [System.Uri] 'http://narvalo.org/7z936.exe' | Install-WebResource -Path $sevenZip

    $sevenZip
}

# .SYNOPSIS
# Install NuGet.
#
# .OUTPUTS
# System.String. Install-7Zip returns a string that contains the path to the NuGet executable.
function Install-NuGet {
    [CmdletBinding()]
    param()
    
    Write-Verbose 'Installing NuGet.'
    
    $nuget = Get-RepositoryPath 'tools', 'NuGet.exe'

    [System.Uri] 'https://nuget.org/nuget.exe' | Install-WebResource -Path $nuget

    $nuget
}

# .SYNOPSIS
# Install PSake.
#
# .PARAMETER NuGet
# The path to the NuGet executable.
#
# .INPUTS
# The path to the NuGet executable.
# 
# .OUTPUTS
# System.String. Install-PSake returns a string that contains the path to the PSake module.
#
# .NOTES
# This function is rather slow to execute.
function Install-PSake {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $false, Position = 0, ValueFromPipeline = $true)] $nuget
    )

    Write-Verbose 'Installing PSake.'
    
    $nuget = ?? $nuget { Install-NuGet }

    Write-Debug 'Call nuget.exe install psake.'
    & $nuget install psake `
       -ExcludeVersion 
       -OutputDirectory (Get-RepositoryPath 'packages') `
       -ConfigFile (Get-RepositoryPath '.nuget', 'NuGet.Config') `
       -Verbosity quiet

    Get-PSakeModulePath -NoVersion
}

# .SYNOPSIS
# Restore packages.
#
# .PARAMETER NuGet
# The path to the NuGet executable.
#
# .INPUTS
# The path to the NuGet executable.
#
# .OUTPUTS
# None.
function Restore-SolutionPackages {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $false, Position = 0, ValueFromPipeline = $true)] $nuget
    )

    Write-Verbose 'Restoring solution packages.'
    
    $nuget = ?? $nuget { Install-NuGet }

    Write-Debug 'Call nuget.exe restore.'
    & $nuget restore (Get-RepositoryPath '.nuget', 'packages.config') `
        -PackagesDirectory (Get-RepositoryPath 'packages') `
        -ConfigFile (Get-RepositoryPath '.nuget', 'NuGet.Config') `
        -Verbosity quiet
}

# ------------------------------------------------------------------------------
# Private methods
# ------------------------------------------------------------------------------

function Install-WebResource {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true, Position = 0, ValueFromPipeline = $true)] [System.Uri] $source,
        [Parameter(Mandatory = $true, Position = 1)] [string] $path
    )

    if (!(Test-Path $path -PathType Leaf)) {
        Write-Verbose "Downloading $source to $path."

        Write-Debug "Download $source."
        Invoke-WebRequest $source -OutFile $path
    }
}

function Get-Git {
    Write-Verbose 'Getting git command.'

    $git = (Get-Command "git.exe" -CommandType Application -ErrorAction SilentlyContinue)

    if ($git -eq $null) { 
        Write-Warning 'Git could not be found in your PATH. Please ensure git is installed.'
    }

    return $git.Path
}

function Join-PathList {
    param(
        [Parameter(Mandatory = $true, Position = 0)] [string[]] $paths
    )

    $count = $paths.Count - 1

    $result = $paths[0]

    for ($i = 1; $i -le $count; $i++) { 
        $result = Join-Path $result $paths[$i]
    }

    $result
}

# ------------------------------------------------------------------------------
# Exports
# ------------------------------------------------------------------------------

Export-ModuleMember -Function `
    Get-GitCommitHash, 
    Get-PSakeModulePath,
    Get-RepositoryPath, 
    Get-RepositoryRoot,
    Install-7Zip,
    Install-NuGet, 
    Install-PSake, 
    Restore-SolutionPackages
