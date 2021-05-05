using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Projectiles
{
	public class LavaBall : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Lava Ball");
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(668);
			aiType = 668;
			projectile.penetrate = -1;
			projectile.ranged = true;
			projectile.timeLeft = 300;
			projectile.extraUpdates = 3;
		}
		public override void AI()
		{
			projectile.alpha = 0;
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
			projectile.type = 668;
			return true;
		}
	}
}