using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Items.Others
{
	public class ThreeSpikes : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault(@"Contains the soul of a legend.
△△△");
		}

		public override void SetDefaults() {
			item.width = 35;
			item.height = 27;
			item.maxStack = 999;
			item.value = 2500000;
			item.rare = ItemRarityID.Red;
		}

	}
}