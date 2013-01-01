namespace NancyMessageHandler.Fluent
{
    public interface IFluentInit
    {
        IHandlerTypeResolver HandlerTypeResolver { get; set; }
        IModuleFactory ModuleFactory { get; set; }
    }
}