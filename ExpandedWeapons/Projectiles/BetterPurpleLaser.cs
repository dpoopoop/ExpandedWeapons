using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Projectiles
{
	public class BetterPurpleLaser : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Better Purple Laser");
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(88);
			aiType = 88;
			projectile.melee = true;
			projectile.timeLeft = 180;
			projectile.extraUpdates = 3;
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
			projectile.type = 88;
			return true;
		}
	}
}