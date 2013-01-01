using System;
using System.Linq;
using System.Reflection;
using NancyMessageHandler.Implementations;

namespace NancyMessageHandler.Fluent
{
    public static class FluntExtensions
    {
        public static ITypedFluentInit UsingTypeResolver(this IFluentInit fluentInit)
        {
            fluentInit.HandlerTypeResolver = HandlerTypeResolver.Init();
            return fluentInit as ITypedFluentInit;
        }


        public static T WithAssemblyModuleTypes<T>(this T fluent, Assembly assembly, Predicate<Type> predicate = null)
            where T: IFluentInit
        {
            var types = assembly.GetTypes().Where(t => typeof(MessageModule).IsAssignableFrom(t));

            if (predicate != null)
                types = types.Where(t => predicate(t));

            var handlers = types.Select(t => (MessageModule)Activator.CreateInstance(t));

            handlers.ToList().ForEach(h => fluent.HandlerTypeResolver.RegisterModule(h));

            return fluent;
        }

        public static T UsingReflectionModuleFactory<T>(this T fluent) where T: IFluentInit
        {
            fluent.ModuleFactory = new ReflectionModuleFactory();
            return fluent;
        }

        public static IMessageHandlerFacade Build<T>(this T fluent) where T: ITypedFluentInit
        {
            return new TypedMessageHandlerFacade(fluent.HandlerTypeResolver, fluent.ModuleFactory);
        }
    }
}