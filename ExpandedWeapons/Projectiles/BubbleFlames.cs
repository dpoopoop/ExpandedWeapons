using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Projectiles
{
	public class BubbleFlames : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bubble Flames"); // The English name of the projectile
		}

		public override void SetDefaults()
		{
			projectile.width = 6; // The width of projectile hitbox
			projectile.height = 6; // The height of projectile hitbox
			projectile.alpha = 0; // This makes the projectile invisible, only showing the dust.
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
			projectile.scale += 0.08f;
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