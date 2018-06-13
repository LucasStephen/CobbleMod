using Terraria.ID;
using Terraria.ModLoader;

namespace CobbleMod.Items
{
	public class GammaPistol : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("GammaPistol");
			Tooltip.SetDefault("He Shot First");
		}
		public override void SetDefaults()
		{
			item.damage = 50;
			item.ranged = true; 	// for ranged weapon
			item.noMelee = true;	// makes sure that bows/tomes dont do melee damage
			item.width = 58;
			item.height = 31;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 5;		// bow use style
			item.shoot = 20;
			item.useAmmo = AmmoID.Bullet;
			item.knockBack = 4;
			item.value = 10000;
			item.rare = 12;
			item.UseSound = SoundID.Item12;
			item.autoReuse = true;
			item.shootSpeed = 15f;
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
