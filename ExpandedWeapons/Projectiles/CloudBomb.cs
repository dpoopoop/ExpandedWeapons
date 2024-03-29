using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Projectiles
{
	public class CloudBomb : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Cloud Bomb");     //The English name of the projectile
			Main.projFrames[projectile.type] = 4;
		}

		public override void SetDefaults() 
		{
			projectile.width = 28;               //The width of projectile hitbox
			projectile.height = 28;              //The height of projectile hitbox
			projectile.aiStyle = 1;             //The ai style of the projectile, please reference the source code of Terraria
			projectile.friendly = false;         //Can the projectile deal damage to enemies?
			projectile.hostile = true;         //Can the projectile deal damage to the player?
			projectile.ranged = true;           //Is the projectile shoot by a ranged weapon?
			projectile.penetrate = -1;           //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
			projectile.timeLeft = 60;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
			projectile.alpha = 255;             //The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in) Make sure to delete this if you aren't using an aiStyle that fades in. You'll wonder why your projectile is invisible.
			projectile.light = 0.5f;            //How much light emit around the projectile
			projectile.ignoreWater = true;          //Does the projectile's speed be influenced by water?
			projectile.tileCollide = false;          //Can the projectile collide with tiles?
			projectile.extraUpdates = 1;            //Set to above 0 if you want the projectile to update multiple time in a frame
			aiType = ProjectileID.Bullet;           //Act exactly like default Bullet
		}
		public override void AI()
		{
			if (projectile.timeLeft <= 20)
		{
			projectile.velocity.X = 0f;
			projectile.velocity.Y = 0f;
		}
			if (++projectile.frameCounter >= 5) 
            {
				projectile.frameCounter = 0;
				if (++projectile.frame >= 4) 
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
			// This code and the similar code above in OnTileCollide spawn dust from the tiles collided with. SoundID.Item10 is the bounce sound you hear.
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			Main.PlaySound(SoundID.Item92, projectile.position);
			int damage = projectile.damage / 2;
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 8, 0, mod.ProjectileType("CloudBolt"), damage, 1f, Main.myPlayer);
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, -8, 0, mod.ProjectileType("CloudBolt"), damage, 1f, Main.myPlayer);
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 8, mod.ProjectileType("CloudBolt"), damage, 1f, Main.myPlayer);
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, -8, mod.ProjectileType("CloudBolt"), damage, 1f, Main.myPlayer);
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 5, -8, mod.ProjectileType("CloudBolt"), damage, 1f, Main.myPlayer);
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 5, 8, mod.ProjectileType("CloudBolt"), damage, 1f, Main.myPlayer);
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, -5, 8, mod.ProjectileType("CloudBolt"), damage, 1f, Main.myPlayer);
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, -5, -8, mod.ProjectileType("CloudBolt"), damage, 1f, Main.myPlayer);
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 8, -5, mod.ProjectileType("CloudBolt"), damage, 1f, Main.myPlayer);
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 8, 5, mod.ProjectileType("CloudBolt"), damage, 1f, Main.myPlayer);
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, -8, 5, mod.ProjectileType("CloudBolt"), damage, 1f, Main.myPlayer);
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, -8, -5, mod.ProjectileType("CloudBolt"), damage, 1f, Main.myPlayer);
		}
	}
}