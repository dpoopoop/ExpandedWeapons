using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.NPCs
{

	
	public class AggressiveNimbus : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Aggressive Nimbus");
		}

		public override void SetDefaults() {
			npc.width = 36;
			npc.height = 36;
			npc.damage = 50;
			npc.defense = 30;
			if (NPC.downedGolemBoss)
        {
            npc.lifeMax = 900;
        }
        else
        {
            npc.lifeMax = 300;
        }
			npc.HitSound = SoundID.NPCHit30;
            npc.DeathSound = SoundID.DD2_KoboldExplosion;
			npc.value = 30f;
			npc.lavaImmune = true;
            npc.noTileCollide = true;
			npc.knockBackResist = 0.05f;
			npc.noGravity = true;
			npc.aiStyle = 74;
			aiType = NPCID.SolarCorite;
		}
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.6);
            npc.damage = (int)(npc.damage * 0.6f);
        }
		public override void NPCLoot()
        {
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, 5f, 0f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, 0f, 5f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, -5f, 0f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, 0f, -5f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, 3f, 3f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, -3f, -3f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, 3f, -3f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, -3f, 3f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, 3f, 0f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, 0f, 3f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, -3f, 0f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, 0f, -3f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, 2f, 2f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, -2f, -2f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, 2f, -2f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, -2f, 2f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, 1f, 0f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, 0f, 1f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, -1f, 0f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, 0f, -1f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, 0.5f, 0.5f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, -0.5f, -0.5f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, 0.5f, -0.5f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, -0.5f, 0.5f, 100, default, 3f);
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			return !spawnInfo.playerSafe && ExpandedNPCWorld.DownedCloudBoss && spawnInfo.player.ZoneRain ? SpawnCondition.OverworldNightMonster.Chance * 0.225f : 0f;
		}
	}
}