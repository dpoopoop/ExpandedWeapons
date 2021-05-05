using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ExpandedWeapons.Projectiles;

namespace ExpandedWeapons.Projectiles
{
	public class RedStar : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Red Star");
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(12);
			aiType = 12;
			projectile.penetrate = 1;
			projectile.ranged = true;
			projectile.timeLeft = 300;
		}
		public override void AI()
		{
			projectile.alpha = 0;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)                
        {
		    target.AddBuff(24, 5 * 60);
			if((!projectile.usesLocalNPCImmunity || projectile.minion) && target.immune[projectile.owner] == 10)
			{
				projectile.usesLocalNPCImmunity = true;
				projectile.localNPCImmunity[target.whoAmI] = 10;
				target.immune[projectile.owner] = 0;
			}
		}	
		public override bool PreKill(int timeLeft) {
			projectile.type = 12;
			return true;
		}
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.DD2_ExplosiveTrapExplode.WithVolume(.5f), (int)projectile.Center.X, (int)projectile.Center.Y);
			Player owner = Main.player[projectile.owner];
            int damage = projectile.damage; 
            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("RedExplosion"), damage, 0, Main.myPlayer);
		}
	}
}