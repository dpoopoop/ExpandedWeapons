using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Projectiles
{
	public class ExcaliburBeam : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("ExcaliburBeam");
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(173);
			aiType = 173;
			projectile.light = 1f;
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
			projectile.type = 173;
			return true;
		}
	}
}