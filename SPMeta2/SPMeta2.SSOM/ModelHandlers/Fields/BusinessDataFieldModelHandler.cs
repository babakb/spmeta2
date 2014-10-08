﻿using SPMeta2.Definitions;
using SPMeta2.Definitions.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPMeta2.Utils;
using System.Xml.Linq;
using SPMeta2.Enumerations;
using Microsoft.SharePoint;

namespace SPMeta2.SSOM.ModelHandlers.Fields
{
    public class BusinessDataFieldModelHandler : FieldModelHandler
    {
        #region properties

        public override Type TargetType
        {
            get { return typeof(BusinessDataFieldDefinition); }
        }

        protected virtual XElement GetMinimalBcsFieldXml()
        {
            return new XElement("Field",
               new XAttribute("Type", BuiltInFieldTypes.BusinessData),
               new XAttribute("Name", string.Empty),
               new XAttribute("Title", string.Empty),
               new XAttribute("StaticName", string.Empty),
               new XAttribute("DisplayName", string.Empty),
               new XAttribute("Required", "FALSE"),
               new XAttribute("ID", String.Empty),
               new XAttribute("SystemInstance", String.Empty),
               new XAttribute("EntityNamespace", String.Empty),
               new XAttribute("EntityName", String.Empty),
               new XAttribute("BdcField", "Title"));
        }

        protected override Type GetTargetFieldType(FieldDefinition model)
        {
            return typeof(SPBusinessDataField);
        }

        #endregion

        #region methods

        protected override void ProcessFieldProperties(SPField field, FieldDefinition fieldModel)
        {
            // let base setting be setup
            base.ProcessFieldProperties(field, fieldModel);

            // process bcs field specific properties
            var bcsField = field.WithAssertAndCast<SPBusinessDataField>("field", value => value.RequireNotNull());
            var bcsFieldModel = fieldModel.WithAssertAndCast<BusinessDataFieldDefinition>("model", value => value.RequireNotNull());

            bcsField.SystemInstanceName = bcsFieldModel.SystemInstanceName;
            bcsField.EntityNamespace = bcsFieldModel.EntityNamespace;

            bcsField.EntityName = bcsFieldModel.EntityName;
            bcsField.BdcFieldName = bcsFieldModel.BdcFieldName;
        }

        protected override string GetTargetSPFieldXmlDefinition(FieldDefinition fieldModel)
        {
            var businessFieldModel = fieldModel.WithAssertAndCast<BusinessDataFieldDefinition>("model", value => value.RequireNotNull());
            var bcsFieldXml = GetMinimalBcsFieldXml();

            bcsFieldXml
                .SetAttribute("Title", businessFieldModel.Title)
                .SetAttribute("DisplayName", businessFieldModel.Title)

                .SetAttribute("Required", businessFieldModel.Required.ToString())

                .SetAttribute("Name", businessFieldModel.InternalName)
                .SetAttribute("StaticName", businessFieldModel.InternalName)

                .SetAttribute("ID", businessFieldModel.Id.ToString("B"))

                .SetAttribute("SystemInstance", businessFieldModel.Title)
                .SetAttribute("EntityNamespace", businessFieldModel.EntityNamespace)
                .SetAttribute("EntityName", businessFieldModel.EntityName)
                .SetAttribute("BdcField", businessFieldModel.BdcFieldName);

            return bcsFieldXml.ToString();
        }

        #endregion
    }

   
}
