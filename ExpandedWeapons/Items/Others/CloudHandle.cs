using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Items.Others
{
	public class CloudHandle : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Used to craft cloud related items'");
		}

		public override void SetDefaults() {
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.value = 100000;
			item.rare = ItemRarityID.Pink;
		}

	}
}