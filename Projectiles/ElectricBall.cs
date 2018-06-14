using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CobbleMod.Projectiles
{
	public class ElectricBall : ModProjectile
	{
		public override void SetDefaults()
		{
            Player p = Main.player[projectile.owner];
            projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 100;
			projectile.timeLeft = 750;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.aiStyle = 0; 
            //projectile.ai[1] = 0;
        }

        public override void AI()
        {
            if (projectile.ai[1] % 13 > 11)
            {
                for (int i = 0; i < Main.projectile.Length; i++)
                {
                    var proj = Main.projectile[i];
                    if (proj.type == mod.ProjectileType("ElectricBall") && proj != projectile && proj.timeLeft > 0)
                    {
                        var projStartX = proj.Center.X;
                        var projStartY = proj.Center.Y;
                        var projEndX = projectile.Center.X;
                        var projEndY = projectile.Center.Y;

                        Projectile.NewProjectile(projStartX, projStartY, projEndX - projStartX, projEndY - projStartY, mod.ProjectileType("Electricity"), (int)(projectile.damage * .50), 0, Main.myPlayer, 0f, 0f);
                    }
                }
            }
            if(projectile.ai[1]++ > 20)
            {
                projectile.velocity.X = 0;
                projectile.velocity.Y = 0;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
		{
            projectile.Kill();
			return false;
		}

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 5; k++)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Sparkle"), projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
			}
			Main.PlaySound(SoundID.Item25, projectile.position);
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
            Player p = Main.player[projectile.owner];
        }
	}
}