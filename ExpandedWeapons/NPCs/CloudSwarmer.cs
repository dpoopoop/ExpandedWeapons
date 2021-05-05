using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using System;
using ExpandedWeapons.Items.Others;
using ExpandedWeapons.Projectiles;

namespace ExpandedWeapons.NPCs
{
	public class CloudSwarmer : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Cloud Swarmer");
		}

		public override void SetDefaults() {
			npc.width = 32;
			npc.height = 32;
			npc.damage = 20;
			npc.defense = 20;
			npc.lavaImmune = true;
            npc.noTileCollide = true;
			if (NPC.downedGolemBoss)
        {
            npc.lifeMax = 120;
        }
        else
        {
            npc.lifeMax = 40;
        }
			npc.HitSound = SoundID.NPCHit3;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 5f;
			npc.knockBackResist = 0.05f;
			npc.noGravity = true;
			npc.aiStyle = 74;
			aiType = NPCID.MartianDrone;
			npc.alpha = 0;
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.6);
            npc.damage = (int)(npc.damage * 0.6f);
        }
    }
}