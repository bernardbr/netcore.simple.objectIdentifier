namespace NetCore.Simple.ObjectIdentifier
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;


    internal static class ObjectIdentifierHelper
    {
        private static IDictionary<Type, Func<object, object>> registrations;

        static ObjectIdentifierHelper()
        {
            registrations = new ConcurrentDictionary<Type, Func<object, object>>();
        }

        internal static void Register<T>(Func<object, T> getByIdMethod)
            where T : class
        {
            if (!registrations.ContainsKey(typeof(T)))
            {
                registrations.Add(typeof(T), getByIdMethod);
            }
        }

        internal static bool GetRegistration(Type interfaceType, out Func<object, object> fn)
        {
            if (registrations.TryGetValue(interfaceType, out fn))
            {
                return true;
            }

            return false;
        }

        internal static bool GetRegistration<T>(out Func<object, T> fn)
        {
            Func<object, object> func;
            var r = GetRegistration(typeof(T), out func);
            fn = (func as Func<object, T>);
            return r;
        }
    }
}