﻿using System.Linq;
using Microsoft.SharePoint.Client;
using SPMeta2.Containers.Assertion;
using SPMeta2.CSOM.ModelHandlers;
using SPMeta2.CSOM.ModelHosts;
using SPMeta2.Definitions;
using SPMeta2.Utils;

namespace SPMeta2.Regression.CSOM.Validation
{
    public class ClientSecurityRoleLinkDefinitionValidator : SecurityRoleLinkModelHandler
    {
        public override void DeployModel(object modelHost, DefinitionBase model)
        {
            var securityGroupModelHost = modelHost.WithAssertAndCast<SecurityGroupModelHost>("modelHost", value => value.RequireNotNull());
            var definition = model.WithAssertAndCast<SecurityRoleLinkDefinition>("model", value => value.RequireNotNull());

            var securableObject = securityGroupModelHost.SecurableObject;
            var securityGroup = securityGroupModelHost.SecurityGroup;
            var securityRole = ResolveSecurityRole(ExtractWeb(securableObject), definition);

            var securityRoleContext = securityRole.Context;
            securityRoleContext.Load(securityRole);
            securityRoleContext.ExecuteQuery();

            var spObject = securableObject.RoleAssignments
                                          .OfType<RoleAssignment>()
                                          .FirstOrDefault(r => r.Member.Id == securityGroup.Id);

            var context = spObject.Context;
            context.Load(spObject, o => o.RoleDefinitionBindings);
            context.ExecuteQuery();

            var assert = ServiceFactory.AssertService.NewAssert(definition, spObject);

            assert
                 .ShouldNotBeNull(spObject);

            if (!string.IsNullOrEmpty(definition.SecurityRoleName))
            {

            }
            else
            {
                assert.SkipProperty(m => m.SecurityRoleName, "SecurityRoleName is null or empty. Skipping.");
            }

            if (!string.IsNullOrEmpty(definition.SecurityRoleType))
            {
                assert.ShouldBeEqual((p, s, d) =>
                {
                    var srcProp = s.GetExpressionValue(m => m.SecurityRoleType);
                    var dstProp = d.GetExpressionValue(o => o.GetRoleDefinitionBindings());

                    var hasRoleDefinitionBinding = spObject.RoleDefinitionBindings
                                                           .FirstOrDefault(b => b.Id == securityRole.Id) != null;

                    return new PropertyValidationResult
                    {
                        Tag = p.Tag,
                        Src = srcProp,
                        Dst = dstProp,
                        IsValid = hasRoleDefinitionBinding
                    };
                });

            }
            else
            {
                assert.SkipProperty(m => m.SecurityRoleType, "SecurityRoleType is null or empty. Skipping.");
            }

            if (definition.SecurityRoleId > 0)
            {

            }
            else
            {
                assert.SkipProperty(m => m.SecurityRoleId, "SecurityRoleId == 0. Skipping.");
            }
        }
    }

    internal static class SPRoleAssignmentExtensinos
    {
        public static string GetRoleDefinitionBindings(this RoleAssignment assignment)
        {
            return assignment.RoleDefinitionBindings.ToString();
        }
    }
}
