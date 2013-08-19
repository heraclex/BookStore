namespace WebApp.CastleConfiguration
{
    using Castle.DynamicProxy;

    /// <summary>
    /// Interceptor for declarative transaction management.
    /// </summary>
    public class CastleTxInterceptor : IInterceptor
    {
        #region Public Methods and Operators

        /// <summary>
        /// Intercept the call
        /// </summary>
        /// <param name="invocation">The invocation object.</param>
        public void Intercept(IInvocation invocation)
        {
            var a = 1;
            //var service = (IService)invocation.InvocationTarget;

            //TODO: will be added EntityFramework wapper later
            // var wrapper = new TxWrapper();
            // wrapper.Wrap(service, invocation.MethodInvocationTarget.Name, service.ConnName, invocation.Proceed);
        }

        #endregion
    }
}