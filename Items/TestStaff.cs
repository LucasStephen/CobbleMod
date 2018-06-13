using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CobbleMod.Items
{
	public class CobbleMod : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("This is a modded magic weapon.");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 400;
			item.magic = true;
			item.mana = 1;
			item.width = 40;
			item.height = 40;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 25;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("TeleBall");
			item.shootSpeed = 1f;
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            var iters = 150;
            float dist = 10;
            for (int i = 0; i < iters; i++)
            {
                Projectile.NewProjectile(player.Center.X - dist * (float)System.Math.Cos(2 * System.Math.PI * (double)i / (double)iters),player.Center.Y-dist*(float)System.Math.Sin(2*System.Math.PI*(double)i/(double)iters), -4* (float)System.Math.Cos(2 * System.Math.PI * (double)i / (double)iters), -4* (float)System.Math.Sin(2 * System.Math.PI * (double)i / (double)iters), mod.ProjectileType("TeleBall"), damage, knockBack, Main.myPlayer, 0f, 0f); //Spawning a projectile
            }
            return false;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}