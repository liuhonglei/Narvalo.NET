﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Narvalo {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Strings_Common {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Strings_Common() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Narvalo.Strings_Common", typeof(Strings_Common).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The supplied value &apos;{0}&apos; is not a well-formed absolute URI..
        /// </summary>
        internal static string AbsoluteUriValidator_UriIsNotAbsoluteFormat {
            get {
                return ResourceManager.GetString("AbsoluteUriValidator_UriIsNotAbsoluteFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0}: {1:N0} cps; ({2:N0} iterations in {3:N0} ticks; {4:N0} ticks per iteration).
        /// </summary>
        internal static string BenchmarkMetric_MetricFormat {
            get {
                return ResourceManager.GetString("BenchmarkMetric_MetricFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &lt;{0}&gt; section is not defined in your config file!.
        /// </summary>
        internal static string ConfigurationManager_MissingSectionFormat {
            get {
                return ResourceManager.GetString("ConfigurationManager_MissingSectionFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Illegal character &apos;{0}&apos; found at position &apos;{1}&apos;..
        /// </summary>
        internal static string Int64Encoder_IllegalCharacterFormat {
            get {
                return ResourceManager.GetString("Int64Encoder_IllegalCharacterFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The length is not less than or equal to &apos;{0}&apos;..
        /// </summary>
        internal static string Int64Encoder_OutOfRangeLengthFormat {
            get {
                return ResourceManager.GetString("Int64Encoder_OutOfRangeLengthFormat", resourceCulture);
            }
        }
    }
}
