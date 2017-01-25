namespace NetCore.Simple.ObjectIdentifier
{
    using System;
    using System.Reflection;

    /// <summary>
    /// The ObjectIdentifier class.
    /// </summary>
    public static class ObjectIdentifier
    {
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
    }
}