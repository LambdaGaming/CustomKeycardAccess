using Exiled.API.Enums;
using Exiled.API.Features;
using events = Exiled.Events.Handlers;

namespace CustomKeycardAccess
{
    public class Plugin : Plugin<Config>
    {
        private EventHandlers EventHandlers;

		public override void OnEnabled()
		{
			base.OnEnabled();
			EventHandlers = new EventHandlers( this );
			Log.Info( "Successfully loaded." );
		}

		public override void OnDisabled()
		{
			base.OnDisabled();
			EventHandlers = null;
		}
	}
}
