using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Projectiles
{
	public class BetterBolt : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Better Bolt");
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.LostSoulFriendly);
			aiType = 297;
			projectile.penetrate = 3;
			projectile.hostile = false;
            projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.timeLeft = 120;
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
			projectile.type = 297;
			return true;
		}
	}
}