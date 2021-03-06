using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using SPMeta2.Definitions.Webparts;
using SPMeta2.Models;
using SPMeta2.Standard.Definitions.Webparts;
using SPMeta2.Syntax.Default;

namespace SPMeta2.Standard.Syntax
{

    [Serializable]
    [DataContract]
    public class CategoryWebPartModelNode : WebPartModelNode
    {

    }

    public static class CategoryWebPartDefinitionSyntax
    {
        #region methods

        public static TModelNode AddCategoryWebPart<TModelNode>(this TModelNode model, CategoryWebPartDefinition definition)
            where TModelNode : ModelNode, IWebpartHostModelNode, new()
        {
            return AddCategoryWebPart(model, definition, null);
        }

        public static TModelNode AddCategoryWebPart<TModelNode>(this TModelNode model, CategoryWebPartDefinition definition,
            Action<CategoryWebPartModelNode> action)
            where TModelNode : ModelNode, IWebpartHostModelNode, new()
        {
            return model.AddTypedDefinitionNode(definition, action);
        }

        #endregion

        #region array overload

        public static TModelNode AddCategoryWebParts<TModelNode>(this TModelNode model, IEnumerable<CategoryWebPartDefinition> definitions)
           where TModelNode : ModelNode, IWebpartHostModelNode, new()
        {
            foreach (var definition in definitions)
                model.AddDefinitionNode(definition);

            return model;
        }

        #endregion
    }
}
