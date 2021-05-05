using ExpandedWeapons.Projectiles;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Items.Melee
{
	public class DeadlyBlood : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault(@"Hitting an enemy scatters blood.
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
			item.damage = 24;
			item.rare = ItemRarityID.Orange;
			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(silver: 200);
			item.shoot = ModContent.ProjectileType<BloodYoyo>();
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
            recipe.AddIngredient(3317, 1);
            recipe.AddIngredient(175, 8);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}