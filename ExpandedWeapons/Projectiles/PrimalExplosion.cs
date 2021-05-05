using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Projectiles
{
	public class PrimalExplosion : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Primal Explosion");
		}

		public override void SetDefaults()
		{
			projectile.width = 156;
			projectile.alpha = 255;
			projectile.height = 156;
			projectile.aiStyle = 0;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.timeLeft = 10;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
		}
		public override void AI() 
		{
			if (projectile.timeLeft >= 8) {
                Dust.NewDustDirect(projectile.position, 128, 128, DustID.Smoke, 0f, -5f, 100, default, 2f);
				Dust.NewDustDirect(projectile.position, 128, 128, DustID.Smoke, 0f, 5f, 100, default, 2f);
				Dust.NewDustDirect(projectile.position, 128, 128, DustID.Smoke, 5f, 0f, 100, default, 2f);
				Dust.NewDustDirect(projectile.position, 128, 128, DustID.Smoke, -5f, 0f, 100, default, 2f);
                Dust.NewDustDirect(projectile.position, 128, 128, DustID.Smoke, -3f, -3f, 100, default, 2f);
                Dust.NewDustDirect(projectile.position, 128, 128, DustID.Smoke, 3f, -3f, 100, default, 2f);
				Dust.NewDustDirect(projectile.position, 128, 128, DustID.Smoke, 3f, 3f, 100, default, 2f);
                Dust.NewDustDirect(projectile.position, 128, 128, DustID.Smoke, -3f, 3f, 100, default, 2f);
				
				Dust.NewDustDirect(projectile.position, 128, 128, 6, 0f, -5f, 100, default, 2f);
				Dust.NewDustDirect(projectile.position, 128, 128, 6, 0f, 5f, 100, default, 2f);
				Dust.NewDustDirect(projectile.position, 128, 128, 6, 5f, 0f, 100, default, 2f);
				Dust.NewDustDirect(projectile.position, 128, 128, 6, -5f, 0f, 100, default, 2f);
                Dust.NewDustDirect(projectile.position, 128, 128, 6, -3f, -3f, 100, default, 2f);
                Dust.NewDustDirect(projectile.position, 128, 128, 6, 3f, -3f, 100, default, 2f);
				Dust.NewDustDirect(projectile.position, 128, 128, 6, 3f, 3f, 100, default, 2f);
                Dust.NewDustDirect(projectile.position, 128, 128, 6, -3f, 3f, 100, default, 2f);
            }
            Player player = Main.player[projectile.owner];
			projectile.light = 1f;
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)       
        {
            target.AddBuff(24, 5 * 60);
			Main.PlaySound(SoundID.Item14.WithVolume(.5f), (int)projectile.Center.X, (int)projectile.Center.Y);
			if((!projectile.usesLocalNPCImmunity || projectile.minion) && target.immune[projectile.owner] == 10)
			{
				projectile.usesLocalNPCImmunity = true;
				projectile.localNPCImmunity[target.whoAmI] = 10;
				target.immune[projectile.owner] = 0;
			}
        }
	}
}