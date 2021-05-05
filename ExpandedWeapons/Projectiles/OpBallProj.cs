using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ExpandedWeapons.Projectiles;
 
namespace ExpandedWeapons.Projectiles    
 
{
    public class OpBallProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 5;
        }
 
        public override void SetDefaults()
        {
            projectile.width = 34; 
            projectile.height = 34;   
            projectile.hostile = false;  
            projectile.friendly = false; 
            projectile.ignoreWater = true;  
            projectile.timeLeft = 600;     
            projectile.penetrate = -1; 
            projectile.tileCollide = true; 
            projectile.magic = true; 
            projectile.alpha = 64;
            projectile.light = 1f;
        }
 
        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            projectile.rotation += 0.015f; //this is the projectile rotation/spinning speed
             if (++projectile.frameCounter >= 6) 
            {
				projectile.frameCounter = 0;
				if (++projectile.frame >= 5) 
                {
					projectile.frame = 0;
				}
			}
            for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];
 
                
                float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
                float shootToY = target.position.Y + (float)target.height * 0.5f - projectile.Center.Y;
                float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));
 
                
                if (distance < 360f && !target.friendly && target.active && target.CanBeChasedBy())  
                {
                    if (projectile.ai[0] > 6f) //2 seconds fire rate
                    {
                        
                        distance = 1.6f / distance;
 
                        
                        shootToX *= distance * 3;
                        shootToY *= distance * 3;
                        int damage = projectile.damage;        
                        float knockBack = projectile.knockBack;            
                        
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootToX, shootToY, mod.ProjectileType("OpBeam"), damage, knockBack, Main.myPlayer, 0f, 0f); 
                        projectile.ai[0] = 0f;
                    }
                }
            }
            projectile.ai[0] += 1f;
 
        }
    }
}
