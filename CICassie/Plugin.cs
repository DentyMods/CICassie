using System;
using EXILED;

namespace CICassie
{
	public class Plugin : EXILED.Plugin
	{
		public EventHandlers EventHandlers;

		public bool CIEnable;
		public string CISpawnMsg;
		public float CICassieMessageDelay;
		public bool StartNoise;
	

		public override void OnEnable()
		{
			try
			{
				Debug("Initializing event handlers..");
				
				EventHandlers = new EventHandlers(this);

				Events.TeamRespawnEvent += EventHandlers.ChaosISpawn;
				LoadConfig();
				Debug("Config is loading...");

				Info($"CICassie Plugin Has Been Loaded: If you need help join my discord https://discord.gg/2KENbxc");
			}
			catch (Exception e)
			{
				Error($"There was an error loading the plugin: {e}");
			}
		}


		public void ChaosISpawn(ref TeamRespawnEvent ev)
		{

			Events.TeamRespawnEvent += EventHandlers.ChaosISpawn;

		}

		public void LoadConfig()
		{
			CIEnable = Config.GetBool("CICassie_enable", false);
			CISpawnMsg = Config.GetString("CICassie_cispawn_message", "");
			CICassieMessageDelay = Config.GetFloat("CICassie_message_delay", 2f);
			Debug("Config was loaded!");

		}

		public override void OnDisable()
		{
			Events.TeamRespawnEvent -= EventHandlers.ChaosISpawn;
			EventHandlers = null;
		}


		public override void OnReload()
		{
			//This is only fired when you use the EXILED reload command, the reload command will call OnDisable, OnReload, reload the plugin, then OnEnable in that order. There is no GAC bypass, so if you are updating a plugin, it must have a unique assembly name, and you need to remove the old version from the plugins folder
		}

		public override string getName { get; } = "CICassie";
	}
}