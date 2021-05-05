using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace ExpandedWeapons.Projectiles
{
	public class WaveMichi : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Michigun Wave");     //The English name of the projectile
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 10;    //The length of old position to be recorded
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;        //The recording mode
		}
		public override void SetDefaults() {
			projectile.width = 40;
			projectile.height = 40;
			projectile.alpha = 0;
			projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.ranged = true;
			projectile.penetrate = -1;
			projectile.aiStyle = 71;
			projectile.timeLeft = 180;
			projectile.extraUpdates = 2;
			aiType = 409;
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
		public override void AI() {
		projectile.rotation =
				projectile.velocity.ToRotation() +
				MathHelper.ToRadians(90f);
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)                
        {
			target.AddBuff(ModContent.BuffType<Buffs.Pointy>(), 5 * 60);
				target.immune[projectile.owner] = 2;
		}	
		public override bool PreKill(int timeLeft) {
			projectile.type = 409;
			return true;
		}
	}
}