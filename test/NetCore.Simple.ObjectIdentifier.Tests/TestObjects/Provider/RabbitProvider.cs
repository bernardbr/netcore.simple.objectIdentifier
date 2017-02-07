namespace NetCore.Simple.ObjectIdentifier.Tests.TestObjects.Provider
{
    using System;
    using NetCore.Simple.ObjectIdentifier.Tests.TestObjects.Model;
    
    public static class RabbitProvider
    {
         public static IRabbit GetById(dynamic identifiers)
         {
             throw new NotImplementedException("It's always throws.");
         }
    }
}