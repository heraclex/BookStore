﻿using System;
using System.Linq;
using System.Web.Mvc;


namespace Ojb.Framework.WebBase.ModelBinder
{
    using Ojb.Framework.Domain.Interfaces;

    internal class EntityCollectionValueBinder : DefaultModelBinder
    {
        /// <summary>
        ///     Binds the model to a value by using the specified controller context and binding context.
        /// </summary>
        /// <returns>
        ///     The bound value.
        /// </returns>
        /// <param name = "controllerContext">The controller context.</param>
        /// <param name = "bindingContext">The binding context.</param>
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {
            var collectionType = bindingContext.ModelType;
            var collectionEntityType = collectionType.GetGenericArguments().First();

            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (valueProviderResult != null) {
                var rawValue = valueProviderResult.RawValue as string[];

                var countOfEntityIds = rawValue.Length;
                var entities = Array.CreateInstance(collectionEntityType, countOfEntityIds);

                var entityInterfaceType =
                    collectionEntityType.GetInterfaces().First(
                        interfaceType =>
                        interfaceType.IsGenericType &&
                        interfaceType.GetGenericTypeDefinition() == typeof(IEntityWithTypedId<>));

                var idType = entityInterfaceType.GetGenericArguments().First();

                for (var i = 0; i < countOfEntityIds; i++) {
                    string rawId = rawValue[i];

                    if (string.IsNullOrEmpty(rawId)) {
                        return null;
                    }

                    object typedId = (idType == typeof(Guid)) ? new Guid(rawId) : Convert.ChangeType(rawId, idType);
                    object entity = EntityRetriever.GetEntityFor(collectionEntityType, typedId, idType);
                    entities.SetValue(entity, i);
                }

                // base.BindModel(controllerContext, bindingContext);
                return entities;
            }

            return base.BindModel(controllerContext, bindingContext);
        }
    }
}