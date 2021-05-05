using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Projectiles
{
	public class CloudBolt : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Cloud Bolt");
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.DiamondBolt);
			projectile.width = 16;
			projectile.height = 16;
			aiType = 126;
			projectile.penetrate = -1;
			projectile.hostile = true;
            projectile.friendly = false;
			projectile.tileCollide = false;
		}

		public override bool PreKill(int timeLeft) {
			projectile.type = 126;
			return true;
		}
	}
}