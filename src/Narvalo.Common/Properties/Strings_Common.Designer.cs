﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Narvalo.Properties {
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Narvalo.Properties.Strings_Common", typeof(Strings_Common).Assembly);
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
        ///   Looks up a localized string similar to The specified value &apos;{0}&apos; is not a well-formed absolute URI..
        /// </summary>
        internal static string AbsoluteUriValidator_UriIsNotAbsolute_Format {
            get {
                return ResourceManager.GetString("AbsoluteUriValidator_UriIsNotAbsolute_Format", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0}: {1:N0} cps; ({2:N0} iterations in {3:N0} ticks; {4:N0} ticks per iteration).
        /// </summary>
        internal static string BenchmarkMetric_Metric_Format {
            get {
                return ResourceManager.GetString("BenchmarkMetric_Metric_Format", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &lt;{0}&gt; section is not defined in your config file!.
        /// </summary>
        internal static string Configuration_MissingSection_Format {
            get {
                return ResourceManager.GetString("Configuration_MissingSection_Format", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Illegal character &apos;{0}&apos; found at position &apos;{1}&apos;..
        /// </summary>
        internal static string Int64Encoder_IllegalCharacter_Format {
            get {
                return ResourceManager.GetString("Int64Encoder_IllegalCharacter_Format", resourceCulture);
            }
        }
    }
}