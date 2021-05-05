using Microsoft.Xna.Framework;
using ExpandedWeapons.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Items.Melee
{
	public class TwoFacedAgony : ModItem
	{
		public int beamCycle;
		bool OnlyShootOnSwing = true;

		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Shoots black and white beams'");
		}

		public override void SetDefaults() {
			item.damage = 140;
			item.melee = true;
			item.width = 64;
			item.height = 64;
			item.useTime = 19;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
			item.value = Item.sellPrice(silver: 1800);
			item.rare = ItemRarityID.Cyan;
			item.UseSound = SoundID.Item60;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<WhiteBolt>();
			item.shootSpeed = 10f;
			item.crit = 6;
		}
			public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		    {
		    beamCycle += 1;
			if (beamCycle >= 1)
			{
				item.shoot = ModContent.ProjectileType<BlackBolt>();
			}
			if (beamCycle >= 2)
			{
				item.shoot = ModContent.ProjectileType<WhiteBolt>();
				beamCycle = 0;
			}
			return true;
		}
}
}