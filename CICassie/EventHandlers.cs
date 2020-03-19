using System.Collections.Generic;
using EXILED;
using Grenades;
using MEC;

namespace CICassie
{
	public class EventHandlers
	{
		public Plugin plugin;
		public EventHandlers(Plugin plugin) => this.plugin = plugin;

		public IEnumerator<float> CassieMessage(string msg, bool makeHold, bool StartNoise, float delay)
		{
			yield return Timing.WaitForSeconds(delay);
			PlayerManager.localPlayer.GetComponent<MTFRespawn>().RpcPlayCustomAnnouncement(msg, makeHold, StartNoise);
		}


		public void ChaosISpawn(ref TeamRespawnEvent ev)
		{
			Plugin.Info($"CIEnable: {plugin.CIEnable}, CISpawnMsg: {plugin.CISpawnMsg}, CICassieMessageDelay: {plugin.CICassieMessageDelay}");
			if (!plugin.CIEnable)
			{
				return;
			}
			Timing.RunCoroutine(CassieMessage(plugin.CISpawnMsg, false, plugin.StartNoise, plugin.CICassieMessageDelay));
		
		}

	}
}