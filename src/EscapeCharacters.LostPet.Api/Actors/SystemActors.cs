using Akka.Actor;

namespace EscapeCharacters.LostPet.Api.Actors
{
    public static class SystemActors
    {
        public static IActorRef SignalRActor = ActorRefs.Nobody;

        public static IActorRef CommandProcessor = ActorRefs.Nobody;
    }

    public class ActorSystemRefs
    {
        public static ActorSystem ActorSystem;
    }
}