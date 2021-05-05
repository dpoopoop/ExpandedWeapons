using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Projectiles
{
	public class PinkBolt : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			// NO! projectile.aiStyle = 48;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.extraUpdates = 5;
			projectile.timeLeft = 300; // lowered from 300
			projectile.penetrate = -1;
		}

		// Note, this Texture is actually just a blank texture, FYI.
		public override string Texture => "Terraria/Projectile_" + ProjectileID.ShadowBeamFriendly;

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if (projectile.velocity.X != oldVelocity.X)
			{
				projectile.position.X = projectile.position.X + projectile.velocity.X;
				projectile.velocity.X = -oldVelocity.X;
			}
			if (projectile.velocity.Y != oldVelocity.Y)
			{
				projectile.position.Y = projectile.position.Y + projectile.velocity.Y;
				projectile.velocity.Y = -oldVelocity.Y;
			}
			return false; // return false because we are handling collision
		}
		public override void AI()
		{
			projectile.rotation = projectile.velocity.ToRotation();
				for (int i = 0; i < 2; i++)
				{
					projectile.alpha = 255;
					// Important, changed 173 to 178!
					Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 86, projectile.velocity.X, projectile.velocity.Y, 0, default, 1.2f);
					dust.noGravity = true;
			        dust.velocity *= 0.3f;
				}
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)                
        {
			if((!projectile.usesLocalNPCImmunity || projectile.minion) && target.immune[projectile.owner] == 10)
			{
				projectile.usesLocalNPCImmunity = true;
				projectile.localNPCImmunity[target.whoAmI] = 10;
				target.immune[projectile.owner] = 0;
			}
		}	
	}
}