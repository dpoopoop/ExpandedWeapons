using Microsoft.Xna.Framework;
using ExpandedWeapons.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Items.Melee
{
	public class DiamondBlade : ModItem
	{
		public int beamCycle;

		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'GABBER PLEASE'"
			+
			"\n△△△");
		}

		public override void SetDefaults() {
			item.damage = 70;
			item.melee = true;
			item.width = 64;
			item.height = 64;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
			item.value = Item.sellPrice(platinum: 1);
			item.rare = ItemRarityID.Purple;
			item.UseSound = SoundID.Item60;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<DiamondWave>();
			item.shootSpeed = 90f;
			item.crit = 9;
			item.value = Item.sellPrice(platinum: 1);
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float numberProjectiles = 3;
			float rotation = MathHelper.ToRadians(5);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage * 7, knockBack, player.whoAmI);
			}
			return false;
		}
	}
}