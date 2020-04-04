using Nancy;
using Nancy.TinyIoc;
using works.ei8.EventSourcing.Client;
using works.ei8.Data.Tag.Application;
using works.ei8.Data.Tag.Port.Adapter.IO.Process.Services;

namespace works.ei8.Data.Tag.Port.Adapter.Out.Api
{
    public class CustomBootstrapper : DefaultNancyBootstrapper
    {
        public CustomBootstrapper()
        {
        }

        protected override void ConfigureRequestContainer(TinyIoCContainer container, NancyContext context)
        {
            base.ConfigureRequestContainer(container, context);

            container.Register<IEventSerializer, EventSerializer>(new EventSerializer());
            container.Register<IEventSourceFactory, EventSourceFactory>();
            container.Register<ISettingsService, SettingsService>();
            container.Register<IItemQueryService, ItemQueryService>();
        }
    }
}
