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
	public class CloudDefender : ModProjectile
	{
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
			ExpandedPlayer modPlayer = player.GetModPlayer<ExpandedPlayer>();
			if (player.dead)
			{
				modPlayer.cloudPet = false;
			}
			if (modPlayer.cloudPet)
			{
				projectile.timeLeft = 2;
			}

			for(int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];
                float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
                float shootToY = target.position.Y - projectile.Center.Y;
                float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));
                if(distance < 320f && !target.friendly && target.active && target.CanBeChasedBy())
                {
                    if(projectile.ai[0] > 15f)
                    {
                        distance = 3f / distance;
                        shootToX *= distance * 5;
                        shootToY *= distance * 5;
                        int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootToX, shootToY, mod.ProjectileType("PetBolt"), 50, projectile.knockBack, Main.myPlayer, 0f, 0f);
                            Main.projectile[proj].timeLeft = 300;
                            Main.projectile[proj].netUpdate = true;
                            projectile.netUpdate = true;
                        Main.PlaySound(SoundID.Item75);
                        projectile.ai[0] = -25f;
                    }
                }
                }
            projectile.ai[0] += 1f;
		}
	}
}