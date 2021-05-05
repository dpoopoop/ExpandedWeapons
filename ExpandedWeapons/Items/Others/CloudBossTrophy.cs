using Terraria.ModLoader;
using Terraria.ID;

namespace ExpandedWeapons.Items.Others
{
	public class CloudBossTrophy : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Cloud Trophy");
			Tooltip.SetDefault("'Congratulations, you destroyed a cloud'");
		}

		public override void SetDefaults() {
			item.width = 30;
			item.height = 30;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.value = 50000;
			item.rare = ItemRarityID.LightRed;
			item.createTile = ModContent.TileType<Tiles.CloudTrophy>();
			item.placeStyle = 0;
		}
	}
}