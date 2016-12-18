﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Narvalo.Finance.Properties {
    using System;
    using System.Reflection;
    
    
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
    internal class Strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Strings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Narvalo.Finance.Properties.Strings", typeof(Strings).GetTypeInfo().Assembly);
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
        ///   Looks up a localized string similar to The BIC string MUST be 8 or 11 characters long..
        /// </summary>
        internal static string Bic_InvalidFormat {
            get {
                return ResourceManager.GetString("Bic_InvalidFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to .
        /// </summary>
        internal static string Currency_NotSupportedNeutralCulture {
            get {
                return ResourceManager.GetString("Currency_NotSupportedNeutralCulture", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unknown currency: {0}..
        /// </summary>
        internal static string Currency_UnknownCurrency {
            get {
                return ResourceManager.GetString("Currency_UnknownCurrency", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to .
        /// </summary>
        internal static string CurrencyActivator_MissingCtor {
            get {
                return ResourceManager.GetString("CurrencyActivator_MissingCtor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unknown currency..
        /// </summary>
        internal static string CurrencyNotFoundException_DefaultMessage {
            get {
                return ResourceManager.GetString("CurrencyNotFoundException_DefaultMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The IBAN string MUST be at most 34 characters long and at least 14 characters long..
        /// </summary>
        internal static string Iban_InvalidFormat {
            get {
                return ResourceManager.GetString("Iban_InvalidFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Format string can be only null, an empty string, &quot;G&quot;, &quot;g&quot;, &quot;D&quot;, &quot;d&quot;, &quot;N&quot;, &quot;n&quot;..
        /// </summary>
        internal static string Iban_InvalidFormatSpecification {
            get {
                return ResourceManager.GetString("Iban_InvalidFormatSpecification", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The specified argument MUST be of Money type..
        /// </summary>
        internal static string Money_ArgIsNotMoney {
            get {
                return ResourceManager.GetString("Money_ArgIsNotMoney", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The alphabetic code MUST be composed of exactly 3 characters..
        /// </summary>
        internal static string Sentinel_OutOfRangeCurrencyAlphabeticCode {
            get {
                return ResourceManager.GetString("Sentinel_OutOfRangeCurrencyAlphabeticCode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The numeric code MUST be greater than 0 and strictly less than 1000..
        /// </summary>
        internal static string Sentinel_OutOfRangeCurrencyNumericCode {
            get {
                return ResourceManager.GetString("Sentinel_OutOfRangeCurrencyNumericCode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Found an invalid value ({0}) for the minor units..
        /// </summary>
        internal static string SnvDataHelpers_InvalidMinorUnits {
            get {
                return ResourceManager.GetString("SnvDataHelpers_InvalidMinorUnits", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Found an invalid value ({0}) for the numeric code..
        /// </summary>
        internal static string SnvDataHelpers_InvalidNumericCode {
            get {
                return ResourceManager.GetString("SnvDataHelpers_InvalidNumericCode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Found an invalid value ({0}) for the publication date..
        /// </summary>
        internal static string SnvDataHelpers_InvalidPubDate {
            get {
                return ResourceManager.GetString("SnvDataHelpers_InvalidPubDate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The numeric code ({0}) MUST be strictly greater than 0 and strictly less than 1000..
        /// </summary>
        internal static string SnvDataHelpers_InvalidRangeForNumericCode {
            get {
                return ResourceManager.GetString("SnvDataHelpers_InvalidRangeForNumericCode", resourceCulture);
            }
        }
    }
}
