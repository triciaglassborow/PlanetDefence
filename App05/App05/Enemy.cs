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
        public Enemy(int x, int y) : base(x, y)
        {
        }

        public override void Update(GameTime gameTime)
        {
            float newX, newY;
            if(IsAlive == true)
            {
                //movemtn
            } 
            if(IsAlive == false)
            {
                //dies, score goes up
            }
            base.Update(gameTime);

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
                Position = new Vector2(Position.X, newY); */
            
    }

    
}
