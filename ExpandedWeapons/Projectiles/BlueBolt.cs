using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ExpandedWeapons.Projectiles;

namespace ExpandedWeapons.Projectiles
{
	public class BlueBolt : ModProjectile
{
	public override void SetDefaults()
	{
		projectile.friendly = true;
		projectile.melee = true;
		projectile.penetrate = 1;
		projectile.width = 16;
		projectile.height = 16;
		projectile.alpha = 255;
		projectile.extraUpdates = 5;
	}

	public override void AI()
	{
		projectile.rotation = projectile.velocity.ToRotation();

		for (int i = 0; i < 2; i++)
		{
			Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 56, projectile.velocity.X, projectile.velocity.Y, 0, Color.Blue, 1.2f);
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
	public override void Kill(int timeLeft)
	{
		Main.PlaySound(SoundID.DD2_ExplosiveTrapExplode.WithVolume(.5f), (int)projectile.Center.X, (int)projectile.Center.Y);
			Player owner = Main.player[projectile.owner];
            int damage = projectile.damage; 
            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("BlueExplosion"), damage, 0, Main.myPlayer);

		for (int i = 0; i < 15; i++)
		{
			Dust dust1 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 56, projectile.oldVelocity.X, projectile.oldVelocity.Y, 0, Color.Blue, 1.5f);
			dust1.noGravity = true;
			dust1.velocity *= 0.5f;
		}
	}
}
}