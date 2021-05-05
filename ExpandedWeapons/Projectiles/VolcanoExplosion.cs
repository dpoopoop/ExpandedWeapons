using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Projectiles
{
	public class VolcanoExplosion : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Volcano Explosion");
		}

		public override void SetDefaults()
		{
			projectile.width = 384;
			projectile.alpha = 255;
			projectile.height = 128;
			projectile.aiStyle = 0;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.timeLeft = 30;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
		}
		public override void AI() 
		{
			if (projectile.timeLeft >= 25) {
                Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 127, 0f, -5f, 100, default, 3f);
                Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 127, -3f, -3f, 100, default, 3f);
                Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 127, 3f, -3f, 100, default, 3f);
				Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 0, 0f, -5f, 100, default, 3f);
                Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 0, -3f, -5f, 100, default, 3f);
                Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 0, 3f, -5f, 100, default, 3f);
            }
            Player player = Main.player[projectile.owner];
            projectile.Center = player.Center;
			projectile.light = 1f;
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)       
        {
            target.AddBuff(189, 10 * 60);
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