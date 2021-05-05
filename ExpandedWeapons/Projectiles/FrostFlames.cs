using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Projectiles
{
	public class FrostFlames : ModProjectile
	{
		public override string Texture => "Terraria/Projectile_" + ProjectileID.Flames;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frost Flames"); // The English name of the projectile
		}

		public override void SetDefaults()
		{
			projectile.width = 6; // The width of projectile hitbox
			projectile.height = 6; // The height of projectile hitbox
			projectile.alpha = 255; // This makes the projectile invisible, only showing the dust.
			projectile.friendly = true; // Can the projectile deal damage to enemies?
			projectile.hostile = false; // Can the projectile deal damage to the player?
			projectile.penetrate = -1; // How many monsters the projectile can penetrate. Change this to make the flamethrower pierce more mobs.
			projectile.timeLeft = 60; // A short life time for this projectile to get the flamethrower effect.
			projectile.ignoreWater = false;
			projectile.tileCollide = true;
			projectile.ranged = true;
			projectile.extraUpdates = 2;
		}

		public override void AI()
		{
			// Using a timer, we scale the earliest spawned dust smaller than the rest.
			float dustScale = 0.75f;
			if (projectile.ai[0] == 0f)
				dustScale = 0.3f;
			else if (projectile.ai[0] == 1f)
				dustScale = 0.5f;
			else if (projectile.ai[0] == 2f)
				dustScale = 0.5f;

			if (Main.rand.Next(2) == 0) {
				int dusts = 2; //thiccness of the flames
            for (int i = 0; i < dusts; i++) {
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 160, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100);
				
				// Some dust will be large, the others small and with gravity, to give visual variety.
				if (Main.rand.NextBool(3)) {
					dust.noGravity = true;
					dust.scale *= 3f;
					dust.velocity.X *= 2f;
					dust.velocity.Y *= 2f;
				}
				dust.scale *= 2f;
				dust.velocity *= 1.2f;
				dust.scale *= dustScale;
			}
			}
			projectile.ai[0] += 1f;
		}

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(44, 10 * 60);
            if((!projectile.usesLocalNPCImmunity || projectile.minion) && target.immune[projectile.owner] == 10)
			{
				projectile.usesLocalNPCImmunity = true;
				projectile.localNPCImmunity[target.whoAmI] = 10;
				target.immune[projectile.owner] = 0;
			}
        }

		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			target.AddBuff(44, 5 * 60, false);
		}

		public override void ModifyDamageHitbox(ref Rectangle hitbox)
		{
			// By using ModifyDamageHitbox, we can allow the flames to damage enemies in a larger area than normal without colliding with tiles.
			// Here we adjust the damage hitbox. We adjust the normal 6x6 hitbox and make it 66x66 while moving it left and up to keep it centered.
			int size = 30;
			hitbox.X -= size;
			hitbox.Y -= size;
			hitbox.Width += size * 2;
			hitbox.Height += size * 2;
		}
	}
}