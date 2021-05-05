using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Projectiles
{
    public class ThunderHammerProj : ModProjectile
    {
        public int tete;
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Thunder Hammer");    
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 3;   
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;      
		}
        public override void SetDefaults()
        {
            projectile.width = 44;
            projectile.height = 44;
            projectile.aiStyle = 3;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 300; 
            projectile.light = 0.5f;
            projectile.extraUpdates = 1;  
            aiType = ProjectileID.WoodenBoomerang;
        }
		public override void AI()
		{
			for (int i = 0; i < 200; i++) //this code below handles the aiming and shooting of the minion.
            {
                NPC target = Main.npc[i];
 
                
                float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X; 
                float shootToY = target.position.Y + (float)target.height * 0.5f - projectile.Center.Y;
                float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));
 
                
                if (distance < 800f && !target.friendly && target.active && target.CanBeChasedBy()) //range is 400 pixels. 
                {
                    if (tete > 6000)
                    {
                        
                        distance = 1.6f / distance;
 
                        
                        shootToX *= distance * 3;
                        shootToY *= distance * 3;
                        int damage = projectile.damage;                  
				{
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootToX, shootToY, mod.ProjectileType("ThunderBeam"), damage, 4f, Main.myPlayer, 0f, 0f); 

				}
                        Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 75);
                        tete = 0;
                    }
                }
				tete += 1;
            }
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)                
        {
			target.AddBuff(144, 3 * 60);
			if((!projectile.usesLocalNPCImmunity || projectile.minion) && target.immune[projectile.owner] == 10)
			{
				projectile.usesLocalNPCImmunity = true;
				projectile.localNPCImmunity[target.whoAmI] = 10;
				target.immune[projectile.owner] = 0;
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
    }
}
