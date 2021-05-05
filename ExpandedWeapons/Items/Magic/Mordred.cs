using ExpandedWeapons.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace ExpandedWeapons.Items.Magic
{
	public class Mordred : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Shoots a spread of magical flames'");
		}

		public override void SetDefaults() {
			item.damage = 115;
			item.magic = true;
			item.mana = 10;
			item.width = 69;
			item.height = 31;
			item.useTime = 7;
			item.useAnimation = 21;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 1;
			item.value = Item.sellPrice(silver: 1800);
			item.rare = ItemRarityID.Cyan;
			item.UseSound = SoundID.Item8;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<MordredProj>();
			item.shootSpeed = 25f;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 55f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			return true;
		}
	}
}