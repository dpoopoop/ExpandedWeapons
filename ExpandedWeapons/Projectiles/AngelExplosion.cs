using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Projectiles
{
    public class AngelExplosion : ModProjectile
    {
        public override void SetStaticDefaults() {
            // The English name of this projectile.
            DisplayName.SetDefault("Angel Explosion");
            // How many vertical animation frames its spritesheet has.
            Main.projFrames[projectile.type] = 5;
        }

        public override void SetDefaults() {
            // Initial hitbox size. When we manually spawn it in OnHitNPC of ExampleSolarEruptionProjectile, we increase this as necessary.
            projectile.width = 100;
            projectile.height = 100;
            // The projectile is spawned by a player.
            projectile.friendly = true;
            // The projectile starts at alpha 255, meaning its invisible. 0 alpha is visible, 255 is invisible.
            projectile.alpha = 0;
            // The projectile doesn't move anyways, but ignore water physics as necessary.
            projectile.ignoreWater = true;
            // Spawn and exist for 60 ticks, or 1 full second.
            projectile.timeLeft = 60;
            // Don't despawn upon tile collision
            projectile.tileCollide = false;
            // Never despawn upon hurting an enemy
            projectile.penetrate = -1;
        }

        public override void AI() {
            Player player = Main.player[projectile.owner];
            // Add light in place of the explosion. Color.White can be any color you want, and 1f at the end is a radius multiplier.
            //Lighting.AddLight(projectile.Center, Color.White.ToVector3() * 1f);

            // Make the explosion larger overtime. By the time of death (60 ticks) it grows by 0.6f.
            projectile.ai[1] += 0.035f;
            projectile.scale = projectile.ai[1];

            projectile.ai[0]++;
            // The larger amount of frames the explosion has, the longer it takes to die (still up to 60 ticks.)
            if (projectile.ai[0] >= 5 * Main.projFrames[projectile.type]) {
                projectile.Kill();
                return;
            }

            // Animates the explosion.
           if (++projectile.frameCounter >= 6) 
            {
				projectile.frameCounter = 0;
				if (++projectile.frame >= 5) 
                {
					projectile.frame = 0;
				}
			}

            projectile.Damage();

            // Basic explosion dust
            int dusts = 5;
            for (int i = 0; i < dusts; i++) {
                // If a random number including 0, 1, 2, and 3, lands 0, (basically 25% chance), spawn the dust.
                if (Main.rand.NextBool(3)) {
                    float speed = 6f;
                    // This velocity takes the speed, multiplies it by a random number from 0.5, to 1.2, then rotates it to be evenly spread like a circle based on what dusts is set to, and then randomly offsets it.
                    Vector2 velocity = new Vector2(0f, -speed * Main.rand.NextFloat(0.5f, 1.2f)).RotatedBy(MathHelper.ToRadians(360f / i * dusts + Main.rand.NextFloat(-50f, 50f)));
                    Dust dust1 = Dust.NewDustPerfect(projectile.Center, 111, velocity, 150, Color.White, 1.5f);
                    dust1.noGravity = true;
                }
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
            if((!projectile.usesLocalNPCImmunity || projectile.minion) && target.immune[projectile.owner] == 10)
			{
				projectile.usesLocalNPCImmunity = true;
				projectile.localNPCImmunity[target.whoAmI] = 10;
				target.immune[projectile.owner] = 0;
			}
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor) {
            // Redraw the projectile with its origin on the center of the hitbox, to compensate for hitbox inflation for accurate explosions.
            Texture2D texture = Main.projectileTexture[projectile.type];
            Rectangle rectangle = texture.Frame(1, Main.projFrames[projectile.type], 0, projectile.frame);
            Color color = projectile.GetAlpha(lightColor);

            if (!projectile.hide) {
                spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, rectangle, color, projectile.rotation, rectangle.Size() * 0.5f, projectile.scale, SpriteEffects.None, 0f);
            }
            return false;
        }
    }
}