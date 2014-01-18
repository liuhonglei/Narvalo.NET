﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
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
    internal class SR {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal SR() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Narvalo.SR", typeof(SR).Assembly);
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
        ///   Looks up a localized string similar to The supplied value {0} is not a well-formed absolute URI..
        /// </summary>
        internal static string AbsoluteUriValidator_UriIsNotAbsoluteFormat {
            get {
                return ResourceManager.GetString("AbsoluteUriValidator_UriIsNotAbsoluteFormat", resourceCulture);
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
        ///   Looks up a localized string similar to The type must be of enum type..
        /// </summary>
        internal static string DebugCheck_TypeIsNotEnum {
            get {
                return ResourceManager.GetString("DebugCheck_TypeIsNotEnum", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The type must be a value type..
        /// </summary>
        internal static string DebugCheck_TypeIsNotValueType {
            get {
                return ResourceManager.GetString("DebugCheck_TypeIsNotValueType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Illegal character {0} found at position {1}..
        /// </summary>
        internal static string Int64Encoder_IllegalCharacterFormat {
            get {
                return ResourceManager.GetString("Int64Encoder_IllegalCharacterFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You can not get the underlying value of an empty maybe..
        /// </summary>
        internal static string Maybe_NoneHasNoValue {
            get {
                return ResourceManager.GetString("Maybe_NoneHasNoValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Successful outcome..
        /// </summary>
        internal static string Outcome_Successful {
            get {
                return ResourceManager.GetString("Outcome_Successful", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A successful outcome has no exception..
        /// </summary>
        internal static string Outcome_SuccessfulHasNoException {
            get {
                return ResourceManager.GetString("Outcome_SuccessfulHasNoException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unsuccessful outcome..
        /// </summary>
        internal static string Outcome_Unsuccessful {
            get {
                return ResourceManager.GetString("Outcome_Unsuccessful", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A bad outcome has no value..
        /// </summary>
        internal static string Outcome_UnsuccessfulHasNoValue {
            get {
                return ResourceManager.GetString("Outcome_UnsuccessfulHasNoValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The lower end must be lesser than upper end..
        /// </summary>
        internal static string Range_LowerEndNotLesserThanUpperEnd {
            get {
                return ResourceManager.GetString("Range_LowerEndNotLesserThanUpperEnd", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The parameter {0} is empty..
        /// </summary>
        internal static string Require_ArgumentEmptyFormat {
            get {
                return ResourceManager.GetString("Require_ArgumentEmptyFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The parameter {0} is null..
        /// </summary>
        internal static string Require_ArgumentNullFormat {
            get {
                return ResourceManager.GetString("Require_ArgumentNullFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value is not greater than or equal to {0}..
        /// </summary>
        internal static string Require_NotGreaterThanOrEqualToFormat {
            get {
                return ResourceManager.GetString("Require_NotGreaterThanOrEqualToFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value is not in range {0} / {1}..
        /// </summary>
        internal static string Require_NotInRangeFormat {
            get {
                return ResourceManager.GetString("Require_NotInRangeFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value is not less than or equal to {0}..
        /// </summary>
        internal static string Require_NotLessThanOrEqualToFormat {
            get {
                return ResourceManager.GetString("Require_NotLessThanOrEqualToFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The object &apos;this&apos; is null..
        /// </summary>
        internal static string Require_ObjectNull {
            get {
                return ResourceManager.GetString("Require_ObjectNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The property value is empty..
        /// </summary>
        internal static string Require_PropertyEmpty {
            get {
                return ResourceManager.GetString("Require_PropertyEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The property value is null..
        /// </summary>
        internal static string Require_PropertyNull {
            get {
                return ResourceManager.GetString("Require_PropertyNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The scheme {0} does not support protocol less uri..
        /// </summary>
        internal static string Uri_ProtocolLessUnsupportedSchemeFormat {
            get {
                return ResourceManager.GetString("Uri_ProtocolLessUnsupportedSchemeFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to find attribute for &apos;{0}&apos; with name &apos;{1}&apos;..
        /// </summary>
        internal static string XElement_AttributeNotFoundFormat {
            get {
                return ResourceManager.GetString("XElement_AttributeNotFoundFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to find first child for &apos;{0}&apos; with name &apos;{1}&apos;..
        /// </summary>
        internal static string XElement_FirstChildNotFoundFormat {
            get {
                return ResourceManager.GetString("XElement_FirstChildNotFoundFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to parse attribute &apos;{0}&apos;, line {1}..
        /// </summary>
        internal static string XElement_MalformedAttributeValueFormat {
            get {
                return ResourceManager.GetString("XElement_MalformedAttributeValueFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to parse element &apos;{0}&apos;, line {1}..
        /// </summary>
        internal static string XElement_MalformedElementValueFormat {
            get {
                return ResourceManager.GetString("XElement_MalformedElementValueFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to find next element after {0}..
        /// </summary>
        internal static string XElement_NextElementNotFoundFormat {
            get {
                return ResourceManager.GetString("XElement_NextElementNotFoundFormat", resourceCulture);
            }
        }
    }
}
