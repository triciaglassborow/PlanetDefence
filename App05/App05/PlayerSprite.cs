using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App05
{
    internal class PlayerSprite : Sprite
    {
        
        public PlayerSprite(int x, int y) : base(x, y) { }

        public override void Update(GameTime gameTime)
        {
            

            KeyboardState KeyState = Keyboard.GetState();

            float newX, newY;
            if (KeyState.IsKeyDown(Keys.Right))
            {
                newX = Position.X + PlayerSpeed + deltaTime;
                Position = new Vector2(newX, Position.Y);
            }
            if (KeyState.IsKeyDown(Keys.Left))
            {
                newX = Position.X - PlayerSpeed + deltaTime;
                Position = new Vector2(newX, Position.Y);
            }

            
            
            base.Update(gameTime);

        }
    }
}
