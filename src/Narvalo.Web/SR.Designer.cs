﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.34209
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Narvalo.Web
{


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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Narvalo.Web.SR", typeof(SR).Assembly);
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
        ///   Recherche une chaîne localisée semblable à Invalid HTTP method: {0}..
        /// </summary>
        internal static string HttpHandlerBase_InvalidHttpMethodFormat {
            get {
                return ResourceManager.GetString("HttpHandlerBase_InvalidHttpMethodFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à Invalid request..
        /// </summary>
        internal static string HttpHandlerBase_InvalidRequest {
            get {
                return ResourceManager.GetString("HttpHandlerBase_InvalidRequest", resourceCulture);
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
    }
}
