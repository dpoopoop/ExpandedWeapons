using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Projectiles
{
	public class Betterspore : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Better Spore");
			Main.projFrames[projectile.type] = 5;
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(228);
			aiType = 228;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.timeLeft = 120;
		}
		public override void AI()
		{
			if (++projectile.frameCounter >= 6) 
            {
				projectile.frameCounter = 0;
				if (++projectile.frame >= 5) 
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
			projectile.type = 228;
			return true;
		}
	}
}