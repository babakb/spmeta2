using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SPMeta2.CSOM.ModelHosts;
using SPMeta2.Definitions;
using SPMeta2.Definitions.Base;
using SPMeta2.Definitions.Webparts;
using SPMeta2.Enumerations;
using SPMeta2.Services;
using SPMeta2.Utils;

namespace SPMeta2.CSOM.ModelHandlers.Webparts
{
    public class ImageWebPartModelHandler : WebPartModelHandler
    {
        #region properties

        public override Type TargetType
        {
            get { return typeof(ImageWebPartDefinition); }
        }

        #endregion

        #region methods

        protected override string GetWebpartXmlDefinition(ListItemModelHost listItemModelHost, WebPartDefinitionBase webPartModel)
        {
            var typedModel = webPartModel.WithAssertAndCast<ImageWebPartDefinition>("model", value => value.RequireNotNull());

            var wpXml = WebpartXmlExtensions.LoadWebpartXmlDocument(BuiltInWebPartTemplates.ImageWebPart);

            // TODO, specific XML processing

            return wpXml.ToString();
        }

        #endregion
    }
}
