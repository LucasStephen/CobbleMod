using Terraria.ID;
using Terraria.ModLoader;

namespace CobbleMod.Items
{
	public class AlucardsRender : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alucard's Render");
			Tooltip.SetDefault("Darkened by the Blood of his father");
		}
		public override void SetDefaults()
		{
			item.melee = true;
			item.useTurn = true;
			item.damage = 250;
			item.width = 64;
			item.height = 64;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 1000000;
			item.rare = 12;
			item.UseSound = SoundID.Item15;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("RedKnifeProjectile");
			item.shootSpeed = 10f;
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
