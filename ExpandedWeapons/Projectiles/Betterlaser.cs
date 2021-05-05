using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Projectiles
{
	public class Betterlaser : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Better Laser");
			Main.projFrames[projectile.type] = 3;
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(459);
			aiType = 459;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.timeLeft = 120;
			projectile.extraUpdates = 3;
		}
		public override void AI()
		{
			if (++projectile.frameCounter >= 4) 
            {
				projectile.frameCounter = 0;
				if (++projectile.frame >= 3) 
                {
					projectile.frame = 0;
				}
			}
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
		public override bool PreKill(int timeLeft) {
			projectile.type = 440;
			return true;
		}
	}
}