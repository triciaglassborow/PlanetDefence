using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace App05
{
    internal class BlueEnemy : Sprite
    {
        public BlueEnemy(int x, int y) : base(x, y) { }

        private static readonly TimeSpan pause = TimeSpan.FromMilliseconds(3000);
        private TimeSpan lastTimeAttack;

        public override void Update(GameTime gameTime)
        {
            
            base.Update(gameTime);

            float newX, newY;
            while(IsALive == true)
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

        }
            
    }

    
}
