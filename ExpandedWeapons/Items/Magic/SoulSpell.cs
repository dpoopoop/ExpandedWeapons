using ExpandedWeapons.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Items.Magic
{
	public class SoulSpell : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault(@"Shoots a soul that fires beams at nearby enemies
'Rainbowtastic'");
		}

		public override void SetDefaults() {
			item.damage = 46;
			item.mana = 12;
			item.width = 32;
			item.height = 30;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.magic = true;
			item.value = Item.sellPrice(silver: 800);
			item.rare = ItemRarityID.LightPurple;
			item.UseSound = SoundID.Item20;
			item.autoReuse = false;
			item.shoot = ModContent.ProjectileType<SoulSpellProj>();
			item.shootSpeed = 1.25f;
		}
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            for (int l = 0; l < Main.projectile.Length; l++)
            {                                                                  
                Projectile proj = Main.projectile[l];
                if (proj.active && proj.type == item.shoot && proj.owner == player.whoAmI)
                {
                    proj.active = false;
                }
            }
            return true;
        }
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(531, 1);
			recipe.AddIngredient(575, 15);
			recipe.AddIngredient(520, 15);
			recipe.AddIngredient(521, 15);
			recipe.AddIngredient(548, 15);
			recipe.AddIngredient(549, 15);
			recipe.AddIngredient(547, 15);
			recipe.anyIronBar = true;
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}