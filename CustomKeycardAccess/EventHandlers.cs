using Exiled.API.Enums;
using Exiled.API.Features.Doors;
using Exiled.Events.EventArgs.Player;
using System;
using System.Collections.Generic;

namespace CustomKeycardAccess
{
	public class EventHandlers
	{
		private Plugin plugin;

		public EventHandlers( Plugin plugin ) => this.plugin = plugin;

		public void OnDoorInteract( InteractingDoorEventArgs ev )
		{
			if ( ev.Door.KeycardPermissions != KeycardPermissions.None && ev.Player.CurrentItem != null && ev.Player.CurrentItem.IsKeycard )
			{
				foreach ( KeyValuePair<string, string[]> kv in plugin.Config.AllowList )
				{
					foreach ( string d in kv.Value )
					{
						DoorType doorType = ( DoorType ) Enum.Parse( typeof( DoorType ), d );
						ItemType keycard = ( ItemType ) Enum.Parse( typeof( ItemType ), kv.Key );
						Door door = Door.Get( doorType );
						if ( door == ev.Door && keycard == ev.Player.CurrentItem.Type )
						{
							ev.IsAllowed = true;
							break;
						}
					}
				}
			}
		}
	}
}
