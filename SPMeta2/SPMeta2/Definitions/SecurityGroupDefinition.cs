﻿using SPMeta2.Attributes;
using SPMeta2.Attributes.Regression;
using System;
using SPMeta2.Definitions.Base;
using System.Runtime.Serialization;

namespace SPMeta2.Definitions
{
    /// <summary>
    /// Allows to define and deploy SharePoint security group.
    /// </summary>
    /// 
    [SPObjectTypeAttribute(SPObjectModelType.SSOM, "Microsoft.SharePoint.SPGroup", "Microsoft.SharePoint")]
    [SPObjectTypeAttribute(SPObjectModelType.CSOM, "Microsoft.SharePoint.Client.Group", "Microsoft.SharePoint.Client")]

    [DefaultRootHostAttribute(typeof(SiteDefinition))]
    [DefaultParentHostAttribute(typeof(SiteDefinition))]

    [Serializable]
    [DataContract]
    [ExpectWithExtensionMethod]
    [ExpectArrayExtensionMethod]

    public class SecurityGroupDefinition : DefinitionBase
    {
        #region  constructors

        public SecurityGroupDefinition()
        {

        }

        #endregion

        #region properties

        /// <summary>
        /// Name of the target security group.
        /// </summary>
        /// 
        [ExpectValidation]
        [ExpectRequired]
        public string Name { get; set; }

        /// <summary>
        /// Description of the target security group.
        /// </summary>
        /// 
        [ExpectValidation]
        [ExpectUpdate]
        public string Description { get; set; }

        /// <summary>
        /// Login name of the owner for the target security group.
        /// </summary>
        /// 
        [ExpectValidation]
        [ExpectUpdateAsUser]
        public string Owner { get; set; }

        /// <summary>
        /// Default user login for the target security group.
        /// </summary>
        /// 
        [ExpectValidation]
        public string DefaultUser { get; set; }

        /// <summary>
        /// Membership view options.
        /// </summary>
        [ExpectValidation]
        public bool OnlyAllowMembersViewMembership { get; set; }

        /// <summary>
        /// Flag to mimic out of the box AssociatedOwnerGroup
        /// </summary>
        public bool IsAssociatedVisitorsGroup { get; set; }

        /// <summary>
        /// Flag to mimic AssociatedMemberGroup
        /// </summary>
        public bool IsAssociatedMemberGroup { get; set; }

        /// <summary>
        /// Flag to mimic AssociatedOwnerGroup
        /// </summary>

        public bool IsAssociatedOwnerGroup { get; set; }

        [ExpectValidation]
        public bool? AllowMembersEditMembership { get; set; }

        [ExpectValidation]
        public bool? AllowRequestToJoinLeave { get; set; }

        [ExpectValidation]
        public bool? AutoAcceptRequestToJoinLeave { get; set; }

        #endregion

        #region methods

        public override string ToString()
        {
            return string.Format("Name:[{0}] Description:[{1}]", Name, Description);
        }

        #endregion
    }
}
