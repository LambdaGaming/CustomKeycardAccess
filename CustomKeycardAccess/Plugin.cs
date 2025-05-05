using Exiled.API.Features;
using System;
using events = Exiled.Events.Handlers;

namespace CustomKeycardAccess
{
	public class Plugin : Plugin<Config>
	{
		private EventHandlers EventHandlers;
		public override Version Version { get; } = new Version( 1, 3, 0 );
		public override Version RequiredExiledVersion { get; } = new Version( 9, 5, 0 );
		public override string Author { get; } = "OPGman";

		public override void OnEnabled()
		{
			base.OnEnabled();
			EventHandlers = new EventHandlers( this );
			events.Player.InteractingDoor += EventHandlers.OnDoorInteract;
		}

		public override void OnDisabled()
		{
			base.OnDisabled();
			events.Player.InteractingDoor -= EventHandlers.OnDoorInteract;
			EventHandlers = null;
		}
	}
}
