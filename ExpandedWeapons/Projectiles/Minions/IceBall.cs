using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Projectiles.Minions
{
	public class IceBall : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Ice Ball");
		}

		public override void SetDefaults() {
			projectile.width = 16; //hitbox width in pixels.
			projectile.height = 16; //hitbox height in pixels.
			projectile.aiStyle = 0; //not affected by gravity.
			projectile.friendly = true;
			projectile.minion = true; //does summon damage.
			projectile.penetrate = 1; //the amount of enemies it can hit.
			projectile.timeLeft = 300; //lasts for 300 ticks (5 seconds)
			projectile.light = 0.5f; //emits light.
			projectile.alpha = 255; //the projectile is invisible.
			projectile.tileCollide = true; //dies when it hits a tile.
			projectile.extraUpdates = 3; //the higher the number, the faster your projectile will move.
		}
		public override void AI()
        {
			projectile.rotation += (float)projectile.direction * 0.2f; //projectile spins.
            var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 160, projectile.velocity.X * 0.4f, projectile.velocity.Y * 0.4f, 100, default, 2f); //create a dust trail.
			dust.noGravity = true;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)                
        {
            target.AddBuff(44, 5 * 60); //apply frostburn (ID 44) to the target for 5 seconds.
		}
		public override bool PreKill(int timeLeft) {
			projectile.type = 123; //emit particles on death.
			return true;
		}
	}
}