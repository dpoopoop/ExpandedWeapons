using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Projectiles
{
	public class PetBolt : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Pet Bolt");
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.LostSoulFriendly);
			aiType = 297;
			projectile.penetrate = 1;
			projectile.hostile = false;
            projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.timeLeft = 120;
		}
		public override bool PreKill(int timeLeft) {
			projectile.type = 297;
			return true;
		}
	}
}