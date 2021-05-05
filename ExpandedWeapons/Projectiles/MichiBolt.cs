using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace ExpandedWeapons.Projectiles
{
	public class MichiBolt : ModProjectile
{
	public override void SetDefaults()
	{
		projectile.friendly = true;
		projectile.ranged = true;
		projectile.penetrate = -1;
		projectile.width = 12;
		projectile.height = 12;
		projectile.alpha = 255;
		projectile.extraUpdates = 5;
	}

	public override void AI()
	{
		projectile.rotation = projectile.velocity.ToRotation();

		for (int i = 0; i < 2; i++)
		{
			Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 91, projectile.velocity.X, projectile.velocity.Y, 0, default, 1.2f);
			dust.noGravity = true;
			dust.velocity *= 0.3f;
		}
	}
	public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)                
        {
			int choice = Main.rand.Next(4);
			if (choice == 0) {
				Projectile.NewProjectile(target.position.X + 64, target.position.Y + 36, -12, -12, ModContent.ProjectileType<MediumSpike>(), damage * 3, 1f, projectile.owner, 0f, 1f);
			}
			else if (choice == 1) {
				Projectile.NewProjectile(target.position.X - 64, target.position.Y + 36, 12, -12, ModContent.ProjectileType<MediumSpike>(), damage * 3, 1f, projectile.owner, 0f, 1f);
				}
			else if (choice == 2) {
				Projectile.NewProjectile(target.position.X + 64, target.position.Y - 36, -12, 12, ModContent.ProjectileType<MediumSpike>(), damage * 3, 1f, projectile.owner, 0f, 1f);
			}
			else if (choice == 3) {
				Projectile.NewProjectile(target.position.X - 64, target.position.Y - 36, 12, 12, ModContent.ProjectileType<MediumSpike>(), damage * 3, 1f, projectile.owner, 0f, 1f);
			}
			if((!projectile.usesLocalNPCImmunity || projectile.minion) && target.immune[projectile.owner] == 10)
			{
				projectile.usesLocalNPCImmunity = true;
				projectile.localNPCImmunity[target.whoAmI] = 10;
				target.immune[projectile.owner] = 0;
			}
		}	
	public override void Kill(int timeLeft)
	{
		Main.PlaySound(SoundID.Dig, projectile.Center);

		for (int i = 0; i < 15; i++)
		{
			Dust dust1 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 91, projectile.oldVelocity.X, projectile.oldVelocity.Y, 0, default, 1.5f);
			dust1.noGravity = true;
			dust1.velocity *= 0.5f;
		}
	}
}
}