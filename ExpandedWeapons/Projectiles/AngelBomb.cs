using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ExpandedWeapons.Projectiles;

namespace ExpandedWeapons.Projectiles
{
	public class AngelBomb : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Angel Bomb");     //The English name of the projectile
			//ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;    //The length of old position to be recorded
			//ProjectileID.Sets.TrailingMode[projectile.type] = 0;        //The recording mode
            Main.projFrames[projectile.type] = 6;
		}

		public override void SetDefaults() 
		{
			projectile.width = 14;               //The width of projectile hitbox
			projectile.height = 14;              //The height of projectile hitbox
			projectile.aiStyle = 0;             //The ai style of the projectile, please reference the source code of Terraria
			projectile.friendly = true;         //Can the projectile deal damage to enemies?
			projectile.hostile = false;         //Can the projectile deal damage to the player?
			projectile.magic = true;           //Is the projectile shoot by a ranged weapon?
			projectile.penetrate = 1;           //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
			projectile.timeLeft = 600;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
			projectile.alpha = 0;             //The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in) Make sure to delete this if you aren't using an aiStyle that fades in. You'll wonder why your projectile is invisible.
			projectile.light = 1f;            //How much light emit around the projectile
			projectile.ignoreWater = true;          //Does the projectile's speed be influenced by water?
			projectile.tileCollide = true;          //Can the projectile collide with tiles?
			projectile.extraUpdates = 0;            //Set to above 0 if you want the projectile to update multiple time in a frame
		}
        public override void AI()
        {
			 for(int i = 0; i < 200; i++)
         {
           NPC target = Main.npc[i];
           float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
           float shootToY = target.position.Y - projectile.Center.Y;
           float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));
           if(distance < 80f && !target.friendly && target.active)
            {
               distance = 3f / distance;
               shootToX *= distance * 5;
               shootToY *= distance * 5;
               projectile.velocity.X = shootToX;
               projectile.velocity.Y = shootToY;
            }
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

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor) {
			//Redraw the projectile with the color not influenced by light
			Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
			for (int k = 0; k < projectile.oldPos.Length; k++) {
				Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
			}
			return true;
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.DD2_ExplosiveTrapExplode.WithVolume(.5f), (int)projectile.Center.X, (int)projectile.Center.Y);
			Player owner = Main.player[projectile.owner];
            int damage = projectile.damage; 
            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("AngelExplosion"), damage, 0, Main.myPlayer);
		}
	}
}