﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Narvalo.Mvp.Web.Properties {
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Narvalo.Mvp.Web.Properties.Strings", typeof(Strings).Assembly);
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
        ///   Looks up a localized string similar to Messages can&apos;t be published or subscribed to after the message bus has been closed. In a typical page lifecycle, this happens during &apos;PreRenderComplete&apos;..
        /// </summary>
        internal static string AspNetMessageCoordinator_Closed {
            get {
                return ResourceManager.GetString("AspNetMessageCoordinator_Closed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The AsyncManager property is currently null, however it should have been automatically initialized. This most likely indicates that your control does not inherit from MvpPage or MvpControl..
        /// </summary>
        internal static string HttpPresenter_AsyncManagerPropertyIsNull {
            get {
                return ResourceManager.GetString("HttpPresenter_AsyncManagerPropertyIsNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The HttpContext property is currently null, however it should have been automatically initialized by the HTTP presenter. This most likely indicates that no presenter was bound to the control. Check your presenter bindings..
        /// </summary>
        internal static string HttpPresenter_HttpContextIsNull {
            get {
                return ResourceManager.GetString("HttpPresenter_HttpContextIsNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Model property is currently null, however it should have been automatically initialized by the presenter. This most likely indicates that no presenter was bound to the control. Check your presenter bindings..
        /// </summary>
        internal static string MvpUserControl_ModelPropertyIsNull {
            get {
                return ResourceManager.GetString("MvpUserControl_ModelPropertyIsNull", resourceCulture);
            }
        }
    }
}
