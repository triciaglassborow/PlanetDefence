﻿using Microsoft.Xna.Framework.Input;
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
            
            if (MoveRight == true && MoveLeft == false)
            {
                newY = Position.Y + (EnemySpeed /6.0f) + deltaTime;
                Position = new Vector2(Position.X, newY);
                newX = Position.X + EnemySpeed + deltaTime;
                Position = new Vector2(newX, Position.Y);
            }
            if (MoveLeft == true && MoveRight == false)
            {
                newY = Position.Y + (EnemySpeed / 6.0f) + deltaTime;
                Position = new Vector2(Position.X, newY);
                newX = Position.X - EnemySpeed + deltaTime;
                Position = new Vector2(newX, Position.Y);
            }
            
            base.Update(gameTime);

        }
        
            
    }

    
}
