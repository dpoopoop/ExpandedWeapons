using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ExpandedWeapons.Buffs;
using ExpandedWeapons.Items.Others;
using ExpandedWeapons.NPCs;
using ExpandedWeapons.Projectiles;

namespace ExpandedWeapons.Projectiles.Minions
{
	public class MichigunMagic : ModProjectile
	{
		public int nebulaCooldown;
		public override void SetStaticDefaults()
		{
			Main.projPet[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.ZephyrFish);
			aiType = ProjectileID.ZephyrFish;
			projectile.light = 1f;
		}

		public override bool PreAI()
		{
			Player player = Main.player[projectile.owner];
			player.zephyrfish = false; 
			return true;
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			if (Main.player[projectile.owner].GetModPlayer<ExpandedPlayer>().magicPet == false)
            {
                projectile.Kill();
            }
			ExpandedPlayer modPlayer = player.GetModPlayer<ExpandedPlayer>();
			if (player.dead)
			{
				modPlayer.magicPet = false;
			}
			if (modPlayer.magicPet)
			{
				projectile.timeLeft = 2;
			}
			float distanceFromTarget = 700f;
			Vector2 targetCenter = projectile.position;
			bool foundTarget = false;
			if (player.HasMinionAttackTargetNPC) {
				NPC npc = Main.npc[player.MinionAttackTargetNPC];
				float between = Vector2.Distance(npc.Center, projectile.Center);
				if (between < 2000f) {
					distanceFromTarget = between;
					targetCenter = npc.Center;
					foundTarget = true;
				}
			}
			if (!foundTarget) {
				// This code is required either way, used for finding a target
				for (int i = 0; i < Main.maxNPCs; i++) {
					NPC npc = Main.npc[i];
					if (npc.CanBeChasedBy()) {
						float between = Vector2.Distance(npc.Center, projectile.Center);
						bool closest = Vector2.Distance(projectile.Center, targetCenter) > between;
						bool inRange = between < distanceFromTarget;
						bool lineOfSight = Collision.CanHitLine(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height);
						// Additional check for this specific minion behavior, otherwise it will stop attacking once it dashed through an enemy while flying though tiles afterwards
						// The number depends on various parameters seen in the movement code below. Test different ones out until it works alright
						bool closeThroughWall = between < 100f;
						if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall)) {
							distanceFromTarget = between;
							targetCenter = npc.Center;
							foundTarget = true;
						}
					}
				}
			}
			if (foundTarget) {
				nebulaCooldown += 1;
				if (nebulaCooldown == 30)
			{
				Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, 3455);
			}
			if (nebulaCooldown == 60)
			{
				Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, 3453);
			}
			if (nebulaCooldown == 90)
			{
				Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, 3454);
				nebulaCooldown = 0;
			}
			}
		}
	}
}