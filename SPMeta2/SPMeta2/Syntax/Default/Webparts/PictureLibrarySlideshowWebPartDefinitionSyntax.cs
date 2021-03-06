using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using SPMeta2.Definitions.Webparts;
using SPMeta2.Models;

namespace SPMeta2.Syntax.Default
{

    [Serializable]
    [DataContract]
    public class PictureLibrarySlideshowWebPartModelNode : WebPartModelNode
    {

    }

    public static class PictureLibrarySlideshowWebPartDefinitionSyntax
    {
        #region methods

        public static TModelNode AddPictureLibrarySlideshowWebPart<TModelNode>(this TModelNode model, PictureLibrarySlideshowWebPartDefinition definition)
            where TModelNode : ModelNode, IWebpartHostModelNode, new()
        {
            return AddPictureLibrarySlideshowWebPart(model, definition, null);
        }

        public static TModelNode AddPictureLibrarySlideshowWebPart<TModelNode>(this TModelNode model, PictureLibrarySlideshowWebPartDefinition definition,
            Action<PictureLibrarySlideshowWebPartModelNode> action)
            where TModelNode : ModelNode, IWebpartHostModelNode, new()
        {
            return model.AddTypedDefinitionNode(definition, action);
        }

        #endregion

        #region array overload

        public static TModelNode AddPictureLibrarySlideshowWebParts<TModelNode>(this TModelNode model, IEnumerable<PictureLibrarySlideshowWebPartDefinition> definitions)
           where TModelNode : ModelNode, IWebpartHostModelNode, new()
        {
            foreach (var definition in definitions)
                model.AddDefinitionNode(definition);

            return model;
        }

        #endregion
    }
}
