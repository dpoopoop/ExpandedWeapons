using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Projectiles
{
	public class RedExplosion : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Red Explosion");
		}

		public override void SetDefaults()
		{
			projectile.width = 128;
			projectile.alpha = 255;
			projectile.height = 128;
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
                Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 219, 0f, -5f, 100, default, 1f);
				Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 219, 0f, 5f, 100, default, 1f);
				Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 219, 5f, 0f, 100, default, 1f);
				Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 219, -5f, 0f, 100, default, 1f);
                Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 219, -3f, -3f, 100, default, 1f);
                Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 219, 3f, -3f, 100, default, 1f);
				Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 219, 3f, 3f, 100, default, 1f);
                Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 219, -3f, 3f, 100, default, 1f);
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