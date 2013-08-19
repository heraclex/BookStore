// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AutofacDynamicProxyExtensions.cs" company="OjbSolution">
//   
// </copyright>
// <summary>
//   Defines the AutofacDynamicProxyExtensions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebApp.AutofacConfiguration
{
    using System;
    using System.Linq;
    using Autofac.Builder;
    using Autofac.Core;
    using Castle.DynamicProxy;

    /// <summary>
    /// Autofac Dynamic Proxy Extensions
    /// </summary>
    public static class AutofacDynamicProxyExtensions
    {
        /// <summary>
        /// Dynamic Proxy generator.
        /// </summary>
        private static readonly ProxyGenerator ProxyGenerator = new ProxyGenerator();

        /// <summary>
        /// Enable interface interception on the target type. Interceptors will be determined
        /// via Intercept attributes on the class or interface, or added with InterceptedBy() calls.
        /// </summary>
        /// <typeparam name="TLimit">
        /// Registration limit type.
        /// </typeparam>
        /// <typeparam name="TActivatorData">
        /// Activator data type.
        /// </typeparam>
        /// <typeparam name="TSingleRegistrationStyle">
        /// Registration style.
        /// </typeparam>
        /// <param name="registration">
        /// Registration to apply interception to.
        /// </param>
        /// <param name="inteceptors">
        /// The inteceptors.
        /// </param>
        /// <returns>
        /// Registration builder allowing the registration to be configured.
        /// </returns>
        public static IRegistrationBuilder<TLimit, TActivatorData, TSingleRegistrationStyle>
            InterceptWith<TLimit, TActivatorData, TSingleRegistrationStyle>(
                this IRegistrationBuilder<TLimit, TActivatorData, TSingleRegistrationStyle> registration, params Tuple<IInterceptor, IProxyGenerationHook>[] inteceptors)
        {
            if (registration == null)
            {
                throw new ArgumentNullException("registration");
            }

            registration.RegistrationData.ActivatingHandlers.Add(
                (sender, e) =>
                    {
                        if (e.Component.Services.OfType<IServiceWithType>().Any(
                                swt => !swt.ServiceType.IsInterface || !swt.ServiceType.IsVisible))
                        {
                            throw new InvalidOperationException("Interface proxy only support interface types");
                        }

                        var proxiedInterfaces = e.Instance.GetType().GetInterfaces().Where(i => i.IsVisible).ToArray();

                        if (!proxiedInterfaces.Any())
                        {
                            return;
                        }

                        var theInterface = proxiedInterfaces.First();
                        var interfaces = proxiedInterfaces.Skip(1).ToArray();
                        var instance = e.Instance;
                        foreach (var interceptor in inteceptors)
                        {
                            if (interceptor.Item2 == null)
                            {
                                instance = ProxyGenerator.CreateInterfaceProxyWithTarget(
                                    theInterface, interfaces, instance, interceptor.Item1);
                            }
                            else
                            {
                                var options = new ProxyGenerationOptions(interceptor.Item2);
                                instance = ProxyGenerator.CreateInterfaceProxyWithTarget(
                                    theInterface, interfaces, instance, options, interceptor.Item1);
                            }
                        }

                        e.Instance = instance;
                    });

            return registration;
        }
    }
}