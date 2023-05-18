using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;

namespace App05
{
    public class Enemy : Sprite
    {
        private readonly List<Sprite> Ships;

        public Enemy(int x, int y) : base(x, y) { }

        public void DetectCollision(Sprite sprite)
        {
            foreach(Sprite ship in Ships)
            {
                if (sprite.HasCollided(ship) && sprite.IsAlive)
                {
                    sprite.IsAlive = false;
                    sprite.IsVisible = false;
                }
            }
        }


        public override void Update(GameTime gameTime)
        {
            
            base.Update(gameTime);
            
            float newX, newY;
            if(IsAlive == true)
            {
                newX = Position.X + EnemySpeed + deltaTime;
                Position = new Vector2(newX, Position.Y);
                //pause
                newY = Position.Y + EnemySpeed + deltaTime;
                Position = new Vector2(Position.X, newY);
                //pause
                newX = Position.X - EnemySpeed + deltaTime;
                Position = new Vector2(newX, Position.Y);
                //pause
                newY = Position.Y + EnemySpeed + deltaTime;
                Position = new Vector2(Position.X, newY);
            } 
            if(IsAlive == false)
            {
                newX = Position.X + EnemySpeed + deltaTime;
                Position = new Vector2(newX, Position.Y);
            }

            /*newX = Position.X + EnemySpeed + deltaTime;
                Position = new Vector2(newX, Position.Y);
                //pause
                newY = Position.Y + EnemySpeed + deltaTime;
                Position = new Vector2(Position.X, newY);
                //pause
                newX = Position.X - EnemySpeed + deltaTime;
                Position = new Vector2(newX, Position.Y);
                //pause
                newY = Position.Y + EnemySpeed + deltaTime;
                Position = new Vector2(Position.X, newY);
            */
        }
            
    }

    
}
