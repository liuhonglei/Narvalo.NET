﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.34003
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Narvalo {
    using System;
    
    
    /// <summary>
    ///   Une classe de ressource fortement typée destinée, entre autres, à la consultation des chaînes localisées.
    /// </summary>
    // Cette classe a été générée automatiquement par la classe StronglyTypedResourceBuilder
    // à l'aide d'un outil, tel que ResGen ou Visual Studio.
    // Pour ajouter ou supprimer un membre, modifiez votre fichier .ResX, puis réexécutez ResGen
    // avec l'option /str ou régénérez votre projet VS.
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
        ///   Retourne l'instance ResourceManager mise en cache utilisée par cette classe.
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
        ///   Remplace la propriété CurrentUICulture du thread actuel pour toutes
        ///   les recherches de ressources à l'aide de cette classe de ressource fortement typée.
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
        ///   Recherche une chaîne localisée semblable à The supplied value {0} is not a well-formed absolute URI..
        /// </summary>
        internal static string AbsoluteUriValidator_UriIsNotAbsoluteFormat {
            get {
                return ResourceManager.GetString("AbsoluteUriValidator_UriIsNotAbsoluteFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à The default AssetProvider was not specified..
        /// </summary>
        internal static string AssetManager_DefaultProviderNotConfigured {
            get {
                return ResourceManager.GetString("AssetManager_DefaultProviderNotConfigured", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à The default AssetProvider was not found..
        /// </summary>
        internal static string AssetManager_DefaultProviderNotFound {
            get {
                return ResourceManager.GetString("AssetManager_DefaultProviderNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à Invalid provider type..
        /// </summary>
        internal static string AssetProviderCollection_InvalidProvider {
            get {
                return ResourceManager.GetString("AssetProviderCollection_InvalidProvider", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à The &lt;{0}&gt; section is not defined in your config file!.
        /// </summary>
        internal static string ConfigurationManager_MissingSectionFormat {
            get {
                return ResourceManager.GetString("ConfigurationManager_MissingSectionFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à Missing or invalid query parameter &apos;{0}&apos;..
        /// </summary>
        internal static string HttpHandlerBase_MissingOrInvalidParameterFormat {
            get {
                return ResourceManager.GetString("HttpHandlerBase_MissingOrInvalidParameterFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à HTTP InputStream too large..
        /// </summary>
        internal static string HttpRequestBase_InputStreamTooLarge {
            get {
                return ResourceManager.GetString("HttpRequestBase_InputStreamTooLarge", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à Illegal character {0} found at position {1}..
        /// </summary>
        internal static string Int64Encoder_IllegalCharacterFormat {
            get {
                return ResourceManager.GetString("Int64Encoder_IllegalCharacterFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à Illegal sequence of chars..
        /// </summary>
        internal static string Int64Encoder_IllegalSequence {
            get {
                return ResourceManager.GetString("Int64Encoder_IllegalSequence", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à You can not get the underlying value of an empty maybe..
        /// </summary>
        internal static string Maybe_NoneHasNoValue {
            get {
                return ResourceManager.GetString("Maybe_NoneHasNoValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à The parameter {0} is empty..
        /// </summary>
        internal static string Requires_ArgumentEmptyFormat {
            get {
                return ResourceManager.GetString("Requires_ArgumentEmptyFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à The parameter {0} is null..
        /// </summary>
        internal static string Requires_ArgumentNullFormat {
            get {
                return ResourceManager.GetString("Requires_ArgumentNullFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à The value is not greater than or equal to {0}..
        /// </summary>
        internal static string Requires_NotGreaterThanOrEqualToFormat {
            get {
                return ResourceManager.GetString("Requires_NotGreaterThanOrEqualToFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à The value is not in range {0} / {1}..
        /// </summary>
        internal static string Requires_NotInRangeFormat {
            get {
                return ResourceManager.GetString("Requires_NotInRangeFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à The value is not less than or equal to {0}..
        /// </summary>
        internal static string Requires_NotLessThanOrEqualToFormat {
            get {
                return ResourceManager.GetString("Requires_NotLessThanOrEqualToFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à The object &apos;this&apos; is null..
        /// </summary>
        internal static string Requires_ObjectNull {
            get {
                return ResourceManager.GetString("Requires_ObjectNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à The property value is empty..
        /// </summary>
        internal static string Requires_PropertyEmpty {
            get {
                return ResourceManager.GetString("Requires_PropertyEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à The property value is null..
        /// </summary>
        internal static string Requires_PropertyNull {
            get {
                return ResourceManager.GetString("Requires_PropertyNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à The scheme {0} does not support protocol less uri..
        /// </summary>
        internal static string Uri_ProtocolLessUnsupportedSchemeFormat {
            get {
                return ResourceManager.GetString("Uri_ProtocolLessUnsupportedSchemeFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à The &lt;{0}&gt; section is not defined in your web.config!.
        /// </summary>
        internal static string WebConfigurationManager_SectionNotFoundFormat {
            get {
                return ResourceManager.GetString("WebConfigurationManager_SectionNotFoundFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à The &lt;{0}&gt; section is not defined in your web.config for the virtual path: {1}!.
        /// </summary>
        internal static string WebConfigurationManager_SectionNotFoundInPathFormat {
            get {
                return ResourceManager.GetString("WebConfigurationManager_SectionNotFoundInPathFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à Unable to find attribute for &apos;{0}&apos; with name &apos;{1}&apos;..
        /// </summary>
        internal static string XElement_AttributeNotFoundFormat {
            get {
                return ResourceManager.GetString("XElement_AttributeNotFoundFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à Unable to find first child for &apos;{0}&apos; with name &apos;{1}&apos;..
        /// </summary>
        internal static string XElement_FirstChildNotFoundFormat {
            get {
                return ResourceManager.GetString("XElement_FirstChildNotFoundFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à Unable to parse attribute &apos;{0}&apos;, line {1}..
        /// </summary>
        internal static string XElement_MalformedAttributeValueFormat {
            get {
                return ResourceManager.GetString("XElement_MalformedAttributeValueFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à Unable to parse element &apos;{0}&apos;, line {1}..
        /// </summary>
        internal static string XElement_MalformedElementValueFormat {
            get {
                return ResourceManager.GetString("XElement_MalformedElementValueFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à Unable to find next element after {0}..
        /// </summary>
        internal static string XElement_NextElementNotFoundFormat {
            get {
                return ResourceManager.GetString("XElement_NextElementNotFoundFormat", resourceCulture);
            }
        }
    }
}
