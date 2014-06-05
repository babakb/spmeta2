﻿using System;
using SPMeta2.Common;
using SPMeta2.Definitions;
using SPMeta2.Events;

namespace SPMeta2.ModelHandlers
{
    public abstract class ModelHandlerBase
    {
        #region contructors


        #endregion

        #region properties

        public abstract Type TargetType { get; }

        #endregion

        #region events

        public EventHandler<ModelEventArgs> OnModelEvent;

        public EventHandler<ModelDefinitionEventArgs> OnDeployingModel;
        public EventHandler<ModelDefinitionEventArgs> OnDeployedModel;

        public EventHandler<ModelDefinitionEventArgs> OnRetractingModel;
        public EventHandler<ModelDefinitionEventArgs> OnRetractedModel;

        protected virtual void InvokeOnDeployingModel(DefinitionBase model)
        {
            if (OnDeployingModel != null) OnDeployingModel(this, new ModelDefinitionEventArgs { Model = model });
        }

        protected virtual void InvokeOnDeployedModel(DefinitionBase model)
        {
            if (OnDeployedModel != null) OnDeployedModel(this, new ModelDefinitionEventArgs { Model = model });
        }

        protected virtual void InvokeOnRetractingModel(DefinitionBase model)
        {
            if (OnRetractingModel != null) OnRetractingModel(this, new ModelDefinitionEventArgs { Model = model });
        }

        protected virtual void InvokeOnRetractedModel(DefinitionBase model)
        {
            if (OnRetractedModel != null) OnRetractedModel(this, new ModelDefinitionEventArgs { Model = model });
        }


        #endregion

        #region methods

        public virtual void DeployModel(object modelHost, DefinitionBase model)
        {
            WithDeployModelEvents(model, m => DeployModelInternal(modelHost, m));
        }

        public virtual void RetractModel(object modelHost, DefinitionBase model)
        {
            WithRetractingModelEvents(model, m => RetractModelInternal(modelHost, m));
        }

        protected virtual void DeployModelInternal(object modelHost, DefinitionBase model)
        {

        }

        protected virtual void RetractModelInternal(object modelHost, DefinitionBase model)
        {

        }

        protected void WithDeployModelEvents(DefinitionBase model, Action<DefinitionBase> action)
        {
            InvokeOnDeployingModel(model);

            action(model);

            InvokeOnDeployedModel(model);
        }

        protected void WithRetractingModelEvents(DefinitionBase model, Action<DefinitionBase> action)
        {
            //InvokeOnModelEvents(model, );

            action(model);

            //InvokeOnRetractedModel(model);
        }

        protected void InvokeOnModelEvents<TModelDefinition, TSPObject>(TSPObject rawObject, ModelEventType eventType)
        {
            if (OnModelEvent != null)
            {
                OnModelEvent.Invoke(this, new ModelEventArgs
                {
                    RawModel = rawObject,
                    EventType = eventType
                });
            }
        }


        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelHost"></param>
        /// <param name="model"></param>
        /// <param name="childModelType"></param>
        /// <param name="action"></param>
        public virtual void WithResolvingModelHost(object modelHost, DefinitionBase model, Type childModelType, Action<object> action)
        {
            action(modelHost);
        }


    }
}