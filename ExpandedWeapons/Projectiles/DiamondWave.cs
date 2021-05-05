using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace ExpandedWeapons.Projectiles
{
	public class DiamondWave : ModProjectile
	{
		public int laserCycle;
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Diamond Wave");     //The English name of the projectile
			//ProjectileID.Sets.TrailCacheLength[projectile.type] = 10;    //The length of old position to be recorded
			//ProjectileID.Sets.TrailingMode[projectile.type] = 0;        //The recording mode
		}
		public override void SetDefaults() {
			projectile.width = 40;
			projectile.height = 40;
			projectile.alpha = 0;
			projectile.friendly = true;
			projectile.ignoreWater = true;
			projectile.ranged = true;
			projectile.penetrate = -1;
			projectile.aiStyle = 8;
			projectile.timeLeft = 180;
			aiType = 502;
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
			var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 91, 0, 0, 100, default, 3f);
			dust.noGravity = true;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)                
        {
			target.AddBuff(ModContent.BuffType<Buffs.Pointy>(), 5 * 60);
			if((!projectile.usesLocalNPCImmunity || projectile.minion) && target.immune[projectile.owner] == 10)
			{
				projectile.usesLocalNPCImmunity = true;
				projectile.localNPCImmunity[target.whoAmI] = 10;
				target.immune[projectile.owner] = 0;
			}
		}	
		public override bool PreKill(int timeLeft) {
			projectile.type = 10;
			return true;
		}
	}
}