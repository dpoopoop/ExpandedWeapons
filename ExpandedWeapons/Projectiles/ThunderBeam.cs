using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ExpandedWeapons.Projectiles;
 
namespace ExpandedWeapons.Projectiles     
 
{
    public class ThunderBeam : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 16; 
            projectile.height = 16;   
            projectile.hostile = false;  
            projectile.friendly = true; 
            projectile.ignoreWater = true;  
            projectile.timeLeft = 300;     
            projectile.penetrate = 1; 
            projectile.tileCollide = true; 
            projectile.melee = true; 
            projectile.extraUpdates = 100;
        }
         public override void AI()
        {
            projectile.localAI[0] += 1f;
            if (projectile.localAI[0] > 3f) 
            {
                for (int i = 0; i < 4; i++)
                {
                    projectile.alpha = 255;
                    var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 206, 0, 0, 100, default, 1f);
			        dust.noGravity = true;
                }
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
    }
}
 
        
