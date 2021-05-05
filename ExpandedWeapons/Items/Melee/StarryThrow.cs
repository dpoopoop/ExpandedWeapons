using ExpandedWeapons.Projectiles;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Items.Melee
{
	public class StarryThrow : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault(@"Sometimes shoots a star from the sky.
'A speedy yoyo'");
			ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
		}

		public override void SetDefaults() {
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.width = 24;
			item.height = 24;
			item.useAnimation = 25;
			item.useTime = 25;
			item.shootSpeed = 16f;
			item.knockBack = 2f;
			item.damage = 18;
			item.rare = ItemRarityID.Green;
			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(silver: 100);
			item.shoot = ModContent.ProjectileType<StarryYoyo>();
		}
		private static readonly int[] unwantedPrefixes = new int[] { PrefixID.Terrible, PrefixID.Dull, PrefixID.Shameful, PrefixID.Annoying, PrefixID.Broken, PrefixID.Damaged, PrefixID.Shoddy};
		public override bool AllowPrefix(int pre) {
			if (Array.IndexOf(unwantedPrefixes, pre) > -1) {
				return false;
			}
			return true;
		}
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(65, 1);
            recipe.AddIngredient(3278, 1);
            recipe.AddTile(305);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}