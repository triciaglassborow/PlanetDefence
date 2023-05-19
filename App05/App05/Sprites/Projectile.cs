using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App05
{
    internal class Projectile : Sprite
    {
        public bool isFired = false;
        public Projectile(int x, int y) : base(x, y)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState KeyState = Keyboard.GetState();

            float newX, newY;

            if (KeyState.IsKeyDown(Keys.Space))
            {
                if (!isFired)
                {
                    isFired = true;
                }
            }

            if(isFired)
            {
                newY = Position.Y - PlayerSpeed + deltaTime;
                Position = new Vector2(Position.X, newY);
            }

            base.Update(gameTime);



        }
    }
}
