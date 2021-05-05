using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Projectiles
{
	public class BlueExplosion : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blue Explosion");
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
                Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 56, 0f, -5f, 100, Color.Blue, 1f);
				Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 56, 0f, 5f, 100, Color.Blue, 1f);
				Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 56, 5f, 0f, 100, Color.Blue, 1f);
				Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 56, -5f, 0f, 100, Color.Blue, 1f);
                Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 56, -3f, -3f, 100, Color.Blue, 1f);
                Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 56, 3f, -3f, 100, Color.Blue, 1f);
				Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 56, 3f, 3f, 100, Color.Blue, 1f);
                Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 56, -3f, 3f, 100, Color.Blue, 1f);
            }
            Player player = Main.player[projectile.owner];
			projectile.light = 1f;
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)       
        {
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