namespace WebApp.AutofacConfiguration
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Castle.DynamicProxy;

    /// <summary>
    /// <see cref="IProxyGenerationHook"/> hook to filter method to intercept by names.
    /// </summary>
    public class AutofacMethodNameProxyGenerationHook : IProxyGenerationHook
    {
        /// <summary>
        /// Method names to match
        /// </summary>
        private readonly HashSet<string> methodNamesToMatch;

        /// <summary>
        /// Initializes a new instance of the <see cref="AutofacMethodNameProxyGenerationHook"/> class. 
        /// </summary>
        /// <param name="methodNamesToMatch">
        /// The method names to match for TX handling
        /// </param>
        public AutofacMethodNameProxyGenerationHook(params string[] methodNamesToMatch)
        {
            this.methodNamesToMatch = new HashSet<string>(methodNamesToMatch);
        }

        /// <summary>
        /// Just do nothing. <see cref="IProxyGenerationHook.MethodsInspected"/>
        /// </summary>
        public void MethodsInspected()
        {
            // Do nothing
        }

        /// <summary>
        /// Just do nothing. <see cref="IProxyGenerationHook.NonProxyableMemberNotification"/>
        /// </summary>
        /// <param name="type">The type which declares the non-virtual member.</param><param name="memberInfo">The non-virtual member.</param>
        public void NonProxyableMemberNotification(Type type, MemberInfo memberInfo)
        {
            // Do nothing
        }

        /// <summary>
        /// <see cref="IProxyGenerationHook.ShouldInterceptMethod"/>
        /// </summary>
        /// <param name="type">
        /// The type to check
        /// </param>
        /// <param name="methodInfo">
        /// The method to check.
        /// </param>
        /// <returns>
        /// <value>
        /// true
        /// </value>
        /// if should intercept
        /// </returns>
        public bool ShouldInterceptMethod(Type type, MethodInfo methodInfo)
        {
            var methodName = methodInfo.Name;
            return this.methodNamesToMatch.Any(methodName.StartsWith);
        }
    }
}