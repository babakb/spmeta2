﻿using System;
using Microsoft.SharePoint;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Definitions;
using SPMeta2.Regression.Common.Utils;
using SPMeta2.SSOM.ModelHandlers;
using SPMeta2.Utils;

namespace SPMeta2.Regression.SSOM.Validation
{
    public class SecurityRoleDefinitionValidator : SecurityGroupModelHandler
    {
        protected override void DeployModelInternal(object modelHost, DefinitionBase model)
        {
            var web = modelHost.WithAssertAndCast<SPWeb>("modelHost", value => value.RequireNotNull());
            var securityRoleModel = model.WithAssertAndCast<SecurityRoleDefinition>("model", value => value.RequireNotNull());

            TraceUtils.WithScope(traceScope =>
            {
                var securityRoles = web.RoleDefinitions;
                var spSecurityRole = securityRoles[securityRoleModel.Name];

                traceScope.WriteLine(string.Format("Validate model:[{0}] security role:[{1}]", securityRoleModel, spSecurityRole));

                // assert base properties
                traceScope.WithTraceIndent(trace =>
                {
                    trace.WriteLine(string.Format("Validate Name: model:[{0}] security role:[{1}]", securityRoleModel.Name, spSecurityRole.Name));
                    Assert.AreEqual(securityRoleModel.Name, spSecurityRole.Name);

                    trace.WriteLine(string.Format("Validate Description: model:[{0}] security role:[{1}]", securityRoleModel.Description, spSecurityRole.Description));
                    Assert.AreEqual(securityRoleModel.Description, spSecurityRole.Description);

                    // validate base permissions
                    trace.WriteLine(string.Format("Validate permissions..."));

                    traceScope.WithTraceIndent(permissionTrace =>
                    {
                        foreach (var permission in securityRoleModel.BasePermissions)
                        {
                            trace.WriteLine(string.Format("Validate permission presence: [{0}]", permission));

                            var spPermission = (int)(SPBasePermissions)Enum.Parse(typeof(SPBasePermissions), permission);
                            Assert.IsTrue((spPermission & (int)spSecurityRole.BasePermissions) != 0);
                        }
                    });

                });
            });
        }
    }
}