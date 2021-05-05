using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace ExpandedWeapons.Items.Others
{
	public class MichigunTruffle : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault(@"Summons a Michigun mount that boosts your stats
'Riding on a ship at 4x speed'");
		}

		public override void SetDefaults() {
			item.width = 20;
			item.height = 30;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.sellPrice(platinum: 1);
			item.rare = ItemRarityID.Purple;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Michisummon");
			item.noMelee = true;
			item.mountType = ModContent.MountType<MountMichi>();
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<ThreeSpikes>(), 1);
			recipe.AddIngredient(ItemID.LunarBar, 30);
			recipe.AddIngredient(2429);
			recipe.AddIngredient(2769);
			recipe.AddIngredient(2502);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();

			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(ModContent.ItemType<ThreeSpikes>(), 1);
			recipe2.AddIngredient(ItemID.LunarBar, 30);
			recipe2.AddIngredient(3367);
			recipe2.AddIngredient(2769);
			recipe2.AddIngredient(2502);
			recipe2.AddTile(412);
			recipe2.SetResult(this);
			recipe2.AddRecipe();
		}
	}
}