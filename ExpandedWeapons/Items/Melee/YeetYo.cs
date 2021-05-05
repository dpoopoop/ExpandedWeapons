using ExpandedWeapons.Projectiles;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Items.Melee
{
	public class YeetYo : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Yeet-Yo");
			Tooltip.SetDefault(@"Critical hits inflict cursed flames and ichor
'A super speedy yoyo'");
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
			item.damage = 45;
			item.rare = ItemRarityID.LightRed;
			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(silver: 500);
			item.shoot = ModContent.ProjectileType<YeetYoyo>();
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
			recipe.AddIngredient(3278, 1);
			recipe.AddIngredient(999, 8);
			recipe.AddIngredient(179, 8);
			recipe.AddRecipeGroup("ExpandedWeapons:EvilFire", 8);
            recipe.AddRecipeGroup("ExpandedWeapons:TitaniumBars", 8);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}