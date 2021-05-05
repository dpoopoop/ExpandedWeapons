using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Projectiles
{
	public class PurpleBolt : ModProjectile
{
	public override void SetDefaults()
	{
		projectile.friendly = true;
		projectile.magic = true;
		projectile.penetrate = -1;
		projectile.width = 16;
		projectile.height = 16;
		projectile.alpha = 255;
		projectile.extraUpdates = 3;
	}

	public override void AI()
	{
		projectile.rotation = projectile.velocity.ToRotation();

		for (int i = 0; i < 2; i++)
		{
			Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 112, projectile.velocity.X, projectile.velocity.Y, 0, default, 1.2f);
			dust.noGravity = true;
			dust.velocity *= 0.3f;
		}
	}
	public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)                
        {
			target.AddBuff(153, 5 * 60);
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
			Dust dust1 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 112, projectile.oldVelocity.X, projectile.oldVelocity.Y, 0, default, 1.5f);
			dust1.noGravity = true;
			dust1.velocity *= 0.5f;
		}
	}
}
}