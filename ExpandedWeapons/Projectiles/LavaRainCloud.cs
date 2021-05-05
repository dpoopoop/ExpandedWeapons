using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Projectiles
{
	public class LavaRainCloud : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Lava Rain Cloud");
			Main.projFrames[projectile.type] = 6;
		}

		public override void SetDefaults() {
			projectile.width = 108; //hitbox width in pixels.
			projectile.height = 48; //hitbox height in pixels.
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
			if(projectile.timeLeft % 3 == 0)
            {
			int damage = projectile.damage; 
			Projectile.NewProjectile(projectile.Center.X + MathHelper.Lerp(-32f, 32f, (float)Main.rand.NextDouble()), projectile.Center.Y + 32, 0, 6,  mod.ProjectileType("Lavarain"), damage, 2f, Main.myPlayer, 0f, 0f); 
			}
			if (++projectile.frameCounter >= 7) 
            {
				projectile.frameCounter = 0;
				if (++projectile.frame >= 6) 
                {
					projectile.frame = 0;
				}
			}
			for (int i = 0; i < 200; i++) //this code below handles the aiming and shooting of the minion.
            {
                NPC target = Main.npc[i];
 
                
                float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X; 
                float shootToY = target.position.Y + (float)target.height * 0.5f - projectile.Center.Y;
                float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));
 
                
                if (distance < 600f && !target.friendly && target.active && target.CanBeChasedBy()) //range is 400 pixels. 
                {
                    if (projectile.ai[0] > 60f) //Fires every second. (60 ticks)
                    {
                        
                        distance = 1.6f / distance;
 
                        
                        shootToX *= distance * 3;
                        shootToY *= distance * 3;
                        int damage = projectile.damage;                  
                        
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootToX, shootToY, mod.ProjectileType("LavaBall"), damage * 2, 4f, Main.myPlayer, 0f, 0f); 
                        Main.PlaySound(SoundID.DD2_BetsyFireballShot.WithVolume(.5f), (int)projectile.position.X, (int)projectile.position.Y); //28 is the sound
                        projectile.ai[0] = 0f;
                    }
                }
            }
            projectile.ai[0] += 1f;
		}
	}
}