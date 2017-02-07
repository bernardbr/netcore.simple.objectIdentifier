namespace NetCore.Simple.ObjectIdentifier
{
    using System;
    using System.Reflection;

    /// <summary>
    /// The ObjectIdentifier class.
    /// </summary>
    public static class ObjectIdentifier
    {
        /// <summary>
        /// Gets an ObjectIdentifier for the Interafce Type.
        /// </summary>
        /// <param name="identifiers">The identifiers of object.</param>
        /// <returns>The object identifier.</returns>
        public static TInterface Get<TInterface>(object identifiers)
            where TInterface : class
        {
            if (!typeof(TInterface).GetTypeInfo().IsInterface)
            {
                throw new NotSupportedException($"Object identifier only supports interface types, but {typeof(TInterface).Name} was passed.");
            }

            var proxy = DispatchProxy.Create<TInterface, ObjectIdentifierInterceptor>();
            (proxy as ObjectIdentifierInterceptor).SetIdentifiers(identifiers);
            return proxy;
        }

        /// <summary>
        /// Register the interface and the method for get an object that implements the interface.
        /// </summary>
        /// <param name="getByIdentifiersMethod">The method who gets the real object.</param>
        public static void Register<TInterface>(Func<object, TInterface> getByIdentifiersMethod)
            where TInterface : class
        {
            ObjectIdentifierHelper.Register<TInterface>(getByIdentifiersMethod);
        }
    }
}