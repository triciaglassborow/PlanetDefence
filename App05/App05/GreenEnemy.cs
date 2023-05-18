using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using Microsoft.Xna.Framework.Graphics;

namespace App05
{
    public class GreenEnemy : Enemy
    {
        public GreenEnemy(int x, int y) : base(x, y)
        {

        }

        public override void Update(GameTime gameTime)
        {
            float newX = 5, newY = 5;
            if (MoveRight == true && MoveLeft == false)
            {
                newY = Position.Y + EnemySpeed + deltaTime;
                Position = new Vector2(Position.X, newY);
                newX = Position.X + EnemySpeed + deltaTime;
                Position = new Vector2(newX, Position.Y);
            }
            if (MoveLeft == true && MoveRight == false)
            {
                newX = Position.X - EnemySpeed + deltaTime;
                Position = new Vector2(newX, Position.Y);
            }
            

            base.Update(gameTime);

        }

    }    
}
