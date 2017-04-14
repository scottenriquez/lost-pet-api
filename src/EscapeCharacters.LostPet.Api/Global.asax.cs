using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Akka.Actor;
using Akka.Routing;
using EscapeCharacters.LostPet.Api.Actors;

namespace EscapeCharacters.LostPet.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_End()
        {
            ActorSystemRefs.ActorSystem = ActorSystem.Create("webcrawler");

            ActorSystem actorSystem = ActorSystemRefs.ActorSystem;
            IActorRef router = actorSystem.ActorOf(Props.Empty
                .WithRouter(FromConfig.Instance), "tasker");
            //TODO-LP: put top-level actors here
            //SystemActors.CommandProcessor = actorSystem.ActorOf(Props.Create(() =>
            //    new CommandProcessor(router)), "commands");
            //SystemActors.SignalRActor = actorSystem.ActorOf(Props.Create(() =>
            //    new SignalRActor()), "signalr");
        }
    }
}
