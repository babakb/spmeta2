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
    public class SearchNavigationWebPartModelNode : WebPartModelNode
    {

    }

    public static class SearchNavigationWebPartDefinitionSyntax
    {
        #region methods

        public static TModelNode AddSearchNavigationWebPart<TModelNode>(this TModelNode model, SearchNavigationWebPartDefinition definition)
            where TModelNode : ModelNode, IWebpartHostModelNode, new()
        {
            return AddSearchNavigationWebPart(model, definition, null);
        }

        public static TModelNode AddSearchNavigationWebPart<TModelNode>(this TModelNode model, SearchNavigationWebPartDefinition definition,
            Action<SearchNavigationWebPartModelNode> action)
            where TModelNode : ModelNode, IWebpartHostModelNode, new()
        {
            return model.AddTypedDefinitionNode(definition, action);
        }

        #endregion

        #region array overload

        public static TModelNode AddSearchNavigationWebParts<TModelNode>(this TModelNode model, IEnumerable<SearchNavigationWebPartDefinition> definitions)
           where TModelNode : ModelNode, IWebpartHostModelNode, new()
        {
            foreach (var definition in definitions)
                model.AddDefinitionNode(definition);

            return model;
        }

        #endregion
    }
}
