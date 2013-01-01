namespace NancyMessageHandler.Fluent
{
    public class FluentHandlers : ITypedFluentInit
    {
        public static IFluentInit Init()
        {
            return new FluentHandlers();
        }

        IHandlerTypeResolver IFluentInit.HandlerTypeResolver { get; set; }
        public IModuleFactory ModuleFactory { get; set; }
    }
}