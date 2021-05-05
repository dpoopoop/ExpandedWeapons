using ExpandedWeapons.Projectiles;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Items.Magic
{
	public class OreoObliteratorMk2 : ModItem
	{
		// You can use a vanilla texture for your item by using the format: "Terraria/Item_<Item ID>".
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Oreo Obliterator Mk2");
			Tooltip.SetDefault("Charges up a massive beam that can obliterate anything."
			+
			"\n'Its a big flashlight of awesomeness'"
            +
			"\n△△△");
		}

		public override void SetDefaults()
		{
			// Start by using CloneDefaults to clone all the basic item properties from the vanilla Last Prism.
			// For example, this copies sprite size, use style, sell price, and the item being a magic weapon.
			item.CloneDefaults(ItemID.LastPrism);
			item.mana = 8;
			item.damage = 50;
			item.knockBack = 3.25f;
			item.rare = ItemRarityID.Purple;
			item.shoot = ModContent.ProjectileType<OreoHoldout>();
			item.shootSpeed = 30f;
			item.value = Item.sellPrice(platinum: 1);
		}

		// Because this weapon fires a holdout projectile, it needs to block usage if its projectile already exists.
		public override bool CanUseItem(Player player) => player.ownedProjectileCounts[ModContent.ProjectileType<OreoHoldout>()] <= 0;
	}
}