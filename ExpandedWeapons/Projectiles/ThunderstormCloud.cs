using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Projectiles
{
	public class ThunderstormCloud : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Thunderstorm Cloud");
			Main.projFrames[projectile.type] = 6;
		}

		public override void SetDefaults() {
			projectile.width = 54; //hitbox width in pixels.
			projectile.height = 24; //hitbox height in pixels.
			projectile.aiStyle = 0; //not affected by gravity.
			projectile.friendly = false;
			projectile.magic = true; //does summon damage.
			projectile.penetrate = -1; //the amount of enemies it can hit.
			projectile.timeLeft = 3600; //lasts for 300 ticks (5 seconds)
			projectile.light = 1f; //emits light.
			projectile.alpha = 32; //the projectile is invisible.
			projectile.tileCollide = false; //dies when it hits a tile.
			projectile.extraUpdates = 0; //the higher the number, the faster your projectile will move.
		}
		public override void AI()
		{
			if(projectile.timeLeft % 30 == 0)
            {
				int thunderdamage = projectile.damage; 
				switch (Main.rand.Next(2)) {
				case 0:
					Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y + 80, 0, 0, mod.ProjectileType("Thunder"), thunderdamage, 3f, Main.myPlayer, 0f, 0f);
					break;
				default:
					Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y + 80, 0, 0, mod.ProjectileType("Thunder2"), thunderdamage, 3f, Main.myPlayer, 0f, 0f);
					break;
			}
			}
			if(projectile.timeLeft % 5 == 0)
            {
			int damage = projectile.damage; 
			Projectile.NewProjectile(projectile.Center.X + MathHelper.Lerp(-16f, 16f, (float)Main.rand.NextDouble()), projectile.Center.Y + 16, 0, 6, mod.ProjectileType("Betterrain"), damage, 1f, Main.myPlayer, 0f, 0f);
			}
			if (++projectile.frameCounter >= 7) 
            {
				projectile.frameCounter = 0;
				if (++projectile.frame >= 6) 
                {
					projectile.frame = 0;
				}
			}
		}
	}
}