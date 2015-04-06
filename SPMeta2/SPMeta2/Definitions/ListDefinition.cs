﻿using SPMeta2.Attributes;
using SPMeta2.Attributes.Regression;
using System;
using SPMeta2.Definitions.Base;
using System.Runtime.Serialization;

namespace SPMeta2.Definitions
{
    /// <summary>
    /// Allows to define and deploy SharePoint list.
    /// </summary>
    /// 

    [SPObjectTypeAttribute(SPObjectModelType.SSOM, "Microsoft.SharePoint.SPList", "Microsoft.SharePoint")]
    [SPObjectTypeAttribute(SPObjectModelType.CSOM, "Microsoft.SharePoint.Client.List", "Microsoft.SharePoint.Client")]

    [DefaultRootHostAttribute(typeof(WebDefinition))]
    [DefaultParentHostAttribute(typeof(WebDefinition))]

    [ExpectAddHostExtensionMethod]
    [Serializable] 
    [DataContract]
    [ExpectWithExtensionMethod]
    [ExpectArrayExtensionMethod]

    public class ListDefinition : DefinitionBase
    {
        public ListDefinition()
        {
            Description = string.Empty;
            Hidden = false;
        }

        #region properties


        /// <summary>
        /// Title of the target list.
        /// </summary>
        /// 
        [ExpectValidation]
        [ExpectUpdate]
        [ExpectRequired]
        public string Title { get; set; }

        [ExpectValidation]
        public bool? IrmEnabled { get; set; }

        [ExpectValidation]
        public bool? IrmExpire { get; set; }

        [ExpectValidation]
        public bool? IrmReject { get; set; }

        [ExpectValidation]
        public string DraftVersionVisibility { get; set; }

        /// <summary>
        /// Description of the target list.
        /// </summary>
        /// 
        [ExpectValidation]
        [ExpectUpdate]
        public string Description { get; set; }

        /// <summary>
        /// URL of the target list.
        /// Don't use "list/my-list-name" as URL is calculated by TemplateType/TemplateName properties.
        /// Provision automatically adds '/lists/' if necessary.
        /// 
        /// Use ListDefinition.GetListUrl() methods to resolve particular list URL.
        /// </summary>
        /// 
        [ExpectValidation]
        [ExpectRequired(GroupName = "List Url")]
        public string Url { get; set; }

        /// <summary>
        /// Provided fll conteolober the URL.
        /// If provided, this value will be used withouy any changes or calculations.
        /// </summary>
        [ExpectValidation]
        [ExpectRequired(GroupName = "List Url")]
        public string CustomUrl { get; set; }

        /// <summary>
        /// Template type of the target list.
        /// BuiltInListTemplateTypeId class can be used to utilize out of the box SharePoint list types.
        /// 
        /// Skip TemplateType and use TemplateName property to create list based on custom template.
        /// </summary>
        /// 
        [ExpectValidation]
        [ExpectRequired(GroupName = "List Template")]
        public int TemplateType { get; set; }

        /// <summary>
        /// Template name of the target list. 
        /// This property is used to allow list creation based on custom templates.
        /// </summary>
        /// 
        [ExpectValidation]
        [ExpectRequired(GroupName = "List Template")]
        public string TemplateName { get; set; }

        /// <summary>
        /// Enables content type support on the target list.
        /// </summary>
        /// 
        [ExpectValidation]
        //[ExpectUpdate]
        public bool ContentTypesEnabled { get; set; }

        /// <summary>
        /// Reserved for the future. Is not used.
        /// </summary>
        public bool NeedBreakRoleInheritance { get; set; }

        /// <summary>
        /// Reserved for the future. Is not used.
        /// </summary>
        public bool? NeedToCopyRoleAssignmets { get; set; }

        [ExpectValidation]
        //[ExpectUpdate]
        public bool? EnableAttachments { get; set; }

        [ExpectValidation]
        //[ExpectUpdate]
        public bool? EnableFolderCreation { get; set; }

        [ExpectValidation]
        //[ExpectUpdate]
        public bool? EnableMinorVersions { get; set; }

        [ExpectValidation]
        //[ExpectUpdate]
        public bool? EnableModeration { get; set; }

        [ExpectValidation]
        //[ExpectUpdate]
        public bool? EnableVersioning { get; set; }

        [ExpectValidation]
        //[ExpectUpdate]
        public bool? ForceCheckout { get; set; }

        [ExpectValidation]
        //[ExpectUpdate]
        public bool? Hidden { get; set; }

        [ExpectValidation]
        [ExpectUpdate]
        public bool? NoCrawl { get; set; }

        [ExpectValidation]
        //[ExpectUpdate]
        public bool? OnQuickLaunch { get; set; }

        #endregion

        #region methods

        public override string ToString()
        {
            return string.Format("Title: [{0}] Url: [{1}] TemplateType:[{2}] TemplateName:[{3}]",
                            new[] {
                                Title,
                                Url,
                                TemplateType.ToString(),
                                TemplateName                                
                            });
        }

        #endregion
    }
}
