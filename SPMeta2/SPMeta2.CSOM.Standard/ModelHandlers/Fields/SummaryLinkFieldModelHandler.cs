﻿using System;
using System.Xml.Linq;
using Microsoft.SharePoint.Client;
using SPMeta2.CSOM.ModelHandlers;
using SPMeta2.Definitions;
using SPMeta2.Standard.Definitions.Fields;
using SPMeta2.Utils;

namespace SPMeta2.CSOM.Standard.ModelHandlers.Fields
{
    public class SummaryLinkFieldModelHandler : FieldModelHandler
    {
        #region properties

        public override Type TargetType
        {
            get { return typeof(SummaryLinkFieldDefinition); }
        }

        //protected override Type GetTargetFieldType(FieldDefinition model)
        //{
        //    return typeof(FieldChoice);
        //}

        #endregion

        #region methods

        protected override void ProcessFieldProperties(Field field, FieldDefinition fieldModel)
        {
            // let base setting be setup
            base.ProcessFieldProperties(field, fieldModel);

        }

        protected override void ProcessSPFieldXElement(XElement fieldTemplate, FieldDefinition fieldModel)
        {
            base.ProcessSPFieldXElement(fieldTemplate, fieldModel);

            var typedFieldModel = fieldModel.WithAssertAndCast<SummaryLinkFieldDefinition>("model", value => value.RequireNotNull());

            //fieldTemplate.SetAttribute(BuiltInFieldAttributes.Format, typedFieldModel.EditFormat);
        }

        #endregion
    }
}
