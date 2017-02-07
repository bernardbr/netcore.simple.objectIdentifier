namespace NetCore.Simple.ObjectIdentifier
{
    using System;
    using System.Linq;
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
        /// The real object who is represented by ObjectIdentifier.
        /// </summary>
        private object realObject;

        private void GetRealObject(Type type)
        {
            if (this.realObject != null)
            {
                return;
            }

            Func<object, object> fn;
            if (!ObjectIdentifierHelper.GetRegistration(type, out fn))
            {
                throw new Exception("The interface is not registred.");
            }

            this.realObject = fn(this.identifiers);
        }

        /// <summary>
        /// Intercepts the invocations on ObjectIdentifier object.
        /// </summary>
        /// <param name="targetMethod">The method that was invoked.</param>
        /// <param name="args">The arguments of method.</param>
        /// <returns>The real object.</returns>
        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            if (targetMethod.Name.Contains("get_"))
            {
                var isIdentifierProperty = this.identifiers.GetType().GetTypeInfo().DeclaredProperties.Any(
                    p => p.Name.Equals(targetMethod.Name.Replace("get_", string.Empty))
                );

                if (isIdentifierProperty)
                {
                    return this.identifiers.GetType().GetTypeInfo().GetDeclaredProperty(targetMethod.Name.Replace("get_", string.Empty)).GetValue(this.identifiers);
                }

                this.GetRealObject(targetMethod.DeclaringType);
                return this.realObject.GetType().GetTypeInfo().GetDeclaredProperty(targetMethod.Name.Replace("get_", string.Empty)).GetValue(this.realObject);
            }

            this.GetRealObject(targetMethod.DeclaringType);
            return this.realObject;
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