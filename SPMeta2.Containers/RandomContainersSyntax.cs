﻿using System;
using SPMeta2.Definitions;
using SPMeta2.Definitions.Taxonomy;
using SPMeta2.Models;
using SPMeta2.Regression.Services;
using SPMeta2.Syntax.Default.Extensions;

namespace SPMeta2.Containers
{
    public static class RandomContainersSyntax
    {
        #region constructors

        static RandomContainersSyntax()
        {
            ModelGeneratorService = new ModelGeneratorService();
        }

        #endregion

        #region properties

        public static ModelGeneratorService ModelGeneratorService { get; set; }

        #endregion

        #region syntax

        #region webs

        public static ModelNode AddRandomWeb(this ModelNode model)
        {
            return AddRandomWebPartPage(model, null);
        }

        public static ModelNode AddRandomWeb(this ModelNode model, Action<ModelNode> action)
        {
            return model.AddRandomDefinition<WebDefinition>(action);
        }

        #endregion

        #region webpart pages

        public static ModelNode AddRandomWebPartPage(this ModelNode model)
        {
            return AddRandomWebPartPage(model, null);
        }

        public static ModelNode AddRandomWebPartPage(this ModelNode model, Action<ModelNode> action)
        {
            return model.AddRandomDefinition<WebPartPageDefinition>(action);
        }

        #endregion

        #region publishing pages

        public static ModelNode AddRandomPublishingPage(this ModelNode model)
        {
            return AddRandomWebPartPage(model, null);
        }

        public static ModelNode AddRandomPublishingPage(this ModelNode model, Action<ModelNode> action)
        {
            return model.AddRandomDefinition<PublishingPageDefinition>(action);
        }

        #endregion

        #region lists

        public static ModelNode AddRandomList(this ModelNode model)
        {
            return AddRandomWebPartPage(model, null);
        }

        public static ModelNode AddRandomList(this ModelNode model, Action<ModelNode> action)
        {
            return model.AddRandomDefinition<ListDefinition>(action);
        }

        #endregion

        #region web parts

        public static ModelNode AddRandomWebpart(this ModelNode model)
        {
            return AddRandomWebpart(model, null);
        }

        public static ModelNode AddRandomWebpart(this ModelNode model, Action<ModelNode> action)
        {
            return model.AddRandomDefinition<WebPartDefinition>(action);
        }

        #endregion

        #region taxonomy

        public static ModelNode AddRandomTermStore(this ModelNode model, Action<ModelNode> action)
        {
            return model.AddRandomDefinition<TaxonomyTermStoreDefinition>(action);
        }

        public static ModelNode AddRandomTermGroup(this ModelNode model, Action<ModelNode> action)
        {
            return model.AddRandomDefinition<TaxonomyTermGroupDefinition>(action);
        }

        public static ModelNode AddRandomTermSet(this ModelNode model, Action<ModelNode> action)
        {
            return model.AddRandomDefinition<TaxonomyTermSetDefinition>(action);
        }

        public static ModelNode AddRandomTerm(this ModelNode model, Action<ModelNode> action)
        {
            return model.AddRandomDefinition<TaxonomyTermDefinition>(action);
        }

        #endregion

        #endregion

        #region internal

        public static ModelNode AddRandomDefinition<TDefinition>(this ModelNode model)
            where TDefinition : DefinitionBase
        {
            return AddRandomDefinition<TDefinition>(model, null);
        }

        public static ModelNode AddRandomDefinition<TDefinition>(this ModelNode model, Action<ModelNode> action)
              where TDefinition : DefinitionBase
        {
            return model.AddDefinitionNode(ModelGeneratorService.GetRandomDefinition<TDefinition>(), action);
        }

        #endregion
    }
}
