using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using ExpandedWeapons.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ExpandedWeapons.Buffs;

namespace ExpandedWeapons.Items.Summon
{
	public class WhipOfMichi : ModItem
	{
		public override void SetStaticDefaults()
		{
						DisplayName.SetDefault("Whip of Michi");
			Tooltip.SetDefault("50 summon tag damage"
			+
			"\n20% summon tag critical strike chance"
            +
			"\nHit an enemy to summon Michigun's ship!"
            +
			"\n△△△");
		}
		public override void SetDefaults() {
            item.width = 64;
            item.height = 64;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 16; //Whip animation
            item.useTime = 16; //Whip time
            item.shootSpeed = 55f; //Range
            item.knockBack = 5f;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Throw");
            item.rare = ItemRarityID.Purple;
            item.shoot = ModContent.ProjectileType<WhipOfMichiProj>();
            item.value = Item.sellPrice(platinum: 1);
            item.noMelee = true;
            item.noUseGraphic = true;
            item.channel = true;
            item.autoReuse = true;
            item.summon = true;
            item.damage = 20;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            // How far out the inaccuracy of the shot chain can be.
            float radius = 40f;
            //player.AddBuff(ModContent.BuffType<Buffs.SummonTag>(), 75);
            // Sets ai[1] to the following value to determine the firing direction.
            // The smaller the value of NextFloat(), the more accurate the shot will be. The larger, the less accurate. This changes depending on your radius.
            // NextBool().ToDirectionInt() will have a 50% chance to make it negative instead of positive.
            // The Solar Eruption uses this calculation: Main.rand.NextFloat(0f, 0.5f) * Main.rand.NextBool().ToDirectionInt() * MathHelper.ToRadians(45f);
            float direction = Main.rand.NextFloat(0.25f, 1f) * Main.rand.NextBool().ToDirectionInt() * MathHelper.ToRadians(radius);
            Projectile projectile = Projectile.NewProjectileDirect(player.RotatedRelativePoint(player.MountedCenter), new Vector2(speedX, speedY), type, damage * 50, knockBack, player.whoAmI, 0f, direction);
            // Extra logic for the chain to adjust to item stats, unlike the Solar Eruption.
            if (projectile.modProjectile is WhipOfMichiProj modItem)
            {
                modItem.firingSpeed = item.shootSpeed * 2f / player.meleeSpeed;
                modItem.firingAnimation = item.useAnimation * player.meleeSpeed;
                modItem.firingTime = item.useTime * player.meleeSpeed;
            }
            return false;
        }
	}
}