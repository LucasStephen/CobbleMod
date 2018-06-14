using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CobbleMod.Projectiles
{
	public class Electricity : ModProjectile
	{
        Vector2 initPos;
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 100;
			projectile.timeLeft = 1;
		}

		public override void AI()
		{
            Player p = Main.player[projectile.owner];
            for (int k = 0; k < 5; k++)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, 204, 0, 0);
            }
            initPos = projectile.position;
            if (((projectile.position.X - p.position.X) < 1) && ((projectile.position.Y - p.position.Y) < 1))
            {
                this.Kill(0);
            }
            
        }

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
            
		    projectile.velocity.X = oldVelocity.X;

		    projectile.velocity.Y = oldVelocity.Y;

			return false;
		}

		public override void Kill(int timeLeft)
		{
            /*for (int k = 0; k < 5; k++)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Sparkle"), projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
			}*/
            var dist = projectile.position - initPos;
            for (int k = 0; k < 5; k++)
            {
                Dust.NewDust(projectile.position-((dist)/k), projectile.width, projectile.height, 246, 0, 0);
            }
            Main.PlaySound(SoundID.Item25, projectile.position);
		}

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            float point = 0f;
            // Run an AABB versus Line check to look for collisions, look up AABB collision first to see how it works
            // It will look for collisions on the given line using AABB
            return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), projectile.position,
                initPos, 22, ref point);

            return false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
            for (int k = 0; k < 5; k++)
            {
                //var newPos = new Vector2(initPos.X + distance/ - k, initPos.Y + distance - k);
                Dust.NewDust(target.position, projectile.width*4, projectile.height*4, 228, 0, 0);
            }
        }
	}
}