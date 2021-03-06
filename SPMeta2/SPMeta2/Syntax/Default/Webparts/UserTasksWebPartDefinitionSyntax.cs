using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using SPMeta2.Definitions.Webparts;
using SPMeta2.Models;

namespace SPMeta2.Syntax.Default
{

    [Serializable]
    [DataContract]
    public class UserTasksWebPartModelNode : WebPartModelNode
    {

    }

    public static class UserTasksWebPartDefinitionSyntax
    {
        #region methods

        public static TModelNode AddUserTasksWebPart<TModelNode>(this TModelNode model, UserTasksWebPartDefinition definition)
            where TModelNode : ModelNode, IWebpartHostModelNode, new()
        {
            return AddUserTasksWebPart(model, definition, null);
        }

        public static TModelNode AddUserTasksWebPart<TModelNode>(this TModelNode model, UserTasksWebPartDefinition definition,
            Action<UserTasksWebPartModelNode> action)
            where TModelNode : ModelNode, IWebpartHostModelNode, new()
        {
            return model.AddTypedDefinitionNode(definition, action);
        }

        #endregion

        #region array overload

        public static TModelNode AddUserTasksWebParts<TModelNode>(this TModelNode model, IEnumerable<UserTasksWebPartDefinition> definitions)
           where TModelNode : ModelNode, IWebpartHostModelNode, new()
        {
            foreach (var definition in definitions)
                model.AddDefinitionNode(definition);

            return model;
        }

        #endregion
    }
}
