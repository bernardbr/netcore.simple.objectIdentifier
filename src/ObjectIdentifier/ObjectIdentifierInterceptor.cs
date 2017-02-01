namespace NetCore.Simple.ObjectIdentifier
{
    using System;
    using System.Reflection;

    /// <summary>
    /// The interceptor of <see cref="ObjectIdentifier"/>.
    /// </summary>
    public class ObjectIdentifierInterceptor : DispatchProxy
    {
        /// <summary>
        /// The identifiers of target object.
        /// </summary>
        private object identifiers;

        /// <summary>
        /// Intercepts the invocations on ObjectIdentifier object.
        /// </summary>
        /// <param name="targetMethod">The method that was invoked.</param>
        /// <param name="args">The arguments of method.</param>
        /// <returns>The real object.</returns>
        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            throw new NotImplementedException("Temporary exception.");
        }

        /// <summary>
        /// Sets the identifiers of target object.
        /// </summary>
        /// <param name="identifiers">The identifiers.</param>
        internal void SetIdentifiers(object identifiers)
        {
            this.identifiers = identifiers;
        }
    }
}