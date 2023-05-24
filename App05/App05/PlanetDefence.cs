using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Xml.Schema;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;

namespace App05
{
    public class PlanetDefence : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont font;

        private Texture2D background;

        private Texture2D blueEnemy;
        private Texture2D greenEnemy;
        private Texture2D redEnemy;
        private Texture2D projectile;
        private Texture2D rightWall;
        private Texture2D leftWall;

        private Texture2D player;
        private Texture2D playerProjectile;

        private PlayerSprite playerCharacter;
        private BlueEnemy blueShip;
        private BlueEnemy blueShip2;
        private RedEnemy redShip;

        private RedEnemy redShip2;
        private RedEnemy redShip3;
        private GreenEnemy greenShip;

        private Walls rightBorder;
        private Walls leftBorder;
        private Projectile playerBullet;

        public int points = 0;
        public int spaceCount = 0;

        public bool RunWave1 = false;
        public bool Wave1Started = false;
        public bool Wave2Started = false;

        public PlanetDefence()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 552;
            _graphics.PreferredBackBufferHeight = 764;

            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            player = Content.Load<Texture2D>("player");
            playerProjectile = Content.Load<Texture2D>("playerbullet");

            redEnemy = Content.Load<Texture2D>("Enemy/redEnemy");
            blueEnemy = Content.Load<Texture2D>("Enemy/blueEnemy");
            greenEnemy = Content.Load<Texture2D>("Enemy/greenEnemy");
            projectile = Content.Load<Texture2D>("Enemy/projectile");

            rightWall = Content.Load<Texture2D>("rboundry");
            leftWall = Content.Load<Texture2D>("lBoundry");

            background = Content.Load<Texture2D>("background");

            font = Content.Load<SpriteFont>("Score");
            SetupSprites();
        }

        //gives playersprite its image
        private void SetupSprites()
        {
            playerCharacter = new PlayerSprite(276, 550)
            {
                Image = player
            };
            //wave1
            blueShip = new BlueEnemy(-100,100)
            {
                Image = blueEnemy,
                Wave = 1
            };
            redShip = new RedEnemy(-100, 100)
            {
                Image = redEnemy,
                Wave = 1
            };
            blueShip2 = new BlueEnemy(-100, 100)
            {
                Image = blueEnemy,
                Wave = 1
            };

            //wave2
            redShip2 = new RedEnemy(-100, 100)
            {
                Image = redEnemy,
                Wave = 2
            };
            greenShip = new GreenEnemy(-100, 100)
            {
                Image = greenEnemy,
                Wave = 2
            };
            redShip3 = new RedEnemy(-100, 100)
            {
                Image = redEnemy,
                Wave = 2
            };

            rightBorder = new RightWall(-179, -100)
            {
                Image = rightWall
            };

            leftBorder = new LeftWall(551, -100)
            {
                Image = leftWall
            };

            playerBullet = new Projectile(276, 550)
            {
                Image = playerProjectile
            };
        }
        protected override void Update(GameTime gameTime)
        {
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            KeyboardState KeyState = Keyboard.GetState();
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                RunWave1 = true;

            playerCharacter.Update(gameTime);

            blueShip.Update(gameTime);
            blueShip2.Update(gameTime);
            redShip.Update(gameTime);

            redShip2.Update(gameTime);
            redShip3.Update(gameTime);
            greenShip.Update(gameTime);

            rightBorder.Update(gameTime);
            leftBorder.Update(gameTime);
            playerBullet.Update(gameTime);
            base.Update(gameTime);
            //start wave 1
            if (RunWave1)
            {
                if (blueShip.Wave == 1 && !Wave1Started)
                {
                    blueShip.Position = new Vector2(50, 0);
                    blueShip.EnemySpeed = 3;
                    
                }
                if (blueShip2.Wave == 1 && !Wave1Started)
                {
                    blueShip2.Position = new Vector2(404, 0);
                    blueShip2.EnemySpeed = 3;
                }
                if (redShip.Wave == 1 && !Wave1Started)
                {
                    redShip.Position = new Vector2(227, 0);
                    redShip.EnemySpeed = 3;
                }
                Wave1Started = true;
            }
            //start wave 2
            if(!blueShip.IsAlive && !redShip.IsAlive && !blueShip2.IsAlive)
            {
                if (redShip2.Wave == 2 && !Wave2Started)
                {
                    redShip2.Position = new Vector2(50, 0);
                    redShip2.EnemySpeed = 3;

                }
                if (redShip3.Wave == 2 && !Wave2Started)
                {
                    redShip3.Position = new Vector2(404, 0);
                    redShip3.EnemySpeed = 3;
                }
                if (greenShip.Wave == 2 && !Wave2Started)
                {
                    greenShip.Position = new Vector2(227, 0);
                    greenShip.EnemySpeed = 3;
                }
                Wave2Started = true;
            }
            //collisions

            //player collising wth enemy ship ends the game, brings up death screen
            //wave1
            if (playerCharacter.HasCollided(blueShip))
            {
                //death screen
            }
            if (playerCharacter.HasCollided(redShip))
            {
                //redShip.IsAlive = false;
                //death screen
            }
            if (playerCharacter.HasCollided(blueShip2))
            {
                //death screen
            }

            //wave2
            if (playerCharacter.HasCollided(redShip2))
            {
                //death screen
            }
            if (playerCharacter.HasCollided(redShip3))
            {
                //death screen
            }
            if (playerCharacter.HasCollided(greenShip))
            {
                //death screen
            }

            //enemys hitting right border
            //wave1
            if (rightBorder.HasCollided(blueShip))
            {
                blueShip.MoveRight = true;
                blueShip.MoveLeft = false;
            }
            if (rightBorder.HasCollided(redShip))
            {
                redShip.MoveRight = true;
                redShip.MoveLeft = false;
            }
            if (rightBorder.HasCollided(blueShip2))
            {
                blueShip2.MoveRight = true;
                blueShip2.MoveLeft = false;
            }

            //wave2
            if (rightBorder.HasCollided(redShip2))
            {
                redShip2.MoveRight = true;
                redShip2.MoveLeft = false;
            }
            if (rightBorder.HasCollided(redShip3))
            {
                redShip3.MoveRight = true;
                redShip3.MoveLeft = false;
            }
            if (rightBorder.HasCollided(greenShip))
            {
                greenShip.MoveRight = true;
                greenShip.MoveLeft = false;
            }

            //enemys hitting left border
            if (leftBorder.HasCollided(blueShip))
            {
                blueShip.MoveRight = false;
                blueShip.MoveLeft = true;
            }
            if (leftBorder.HasCollided(redShip))
            {
                redShip.MoveRight = false;
                redShip.MoveLeft = true;
            }
            if (leftBorder.HasCollided(blueShip2))
            {
                blueShip2.MoveRight = false;
                blueShip2.MoveLeft = true;
            }

            //wave2
            if (leftBorder.HasCollided(redShip2))
            {
                redShip2.MoveRight = false;
                redShip2.MoveLeft = true;
            }
            if (leftBorder.HasCollided(redShip3))
            {
                redShip3.MoveRight = false;
                redShip3.MoveLeft = true;
            }
            if (leftBorder.HasCollided(greenShip))
            {
                greenShip.MoveRight = false;
                greenShip.MoveLeft = true;
            }

            //playerBullet hitting enemy and then playerbullet resets
            if (playerBullet.HasCollided(blueShip))
            {
                playerBullet.isFired = false;
                blueShip.IsAlive = false;
                points++;

            }
            if (playerBullet.HasCollided(redShip))
            {
                playerBullet.isFired = false;
                redShip.lives++;
                if (redShip.lives == 2)
                {
                    redShip.IsAlive = false;
                    points += 2;
                } 
            }
            if (playerBullet.HasCollided(blueShip2))
            {
                playerBullet.isFired = false;
                blueShip2.IsAlive = false;
                points++;

            }

            //wave2
            if (playerBullet.HasCollided(redShip2))
            {
                playerBullet.isFired = false;
                redShip2.lives++;
                if (redShip2.lives == 2)
                {
                    redShip2.IsAlive = false;
                    points += 2;
                }
            }
            if (playerBullet.HasCollided(redShip3))
            {
                playerBullet.isFired = false;
                redShip3.lives++;
                if (redShip3.lives == 2)
                {
                    redShip3.IsAlive = false;
                    points += 2;
                }
            }
            if (playerBullet.HasCollided(greenShip))
            {
                playerBullet.isFired = false;
                greenShip.lives++;
                if (greenShip.lives == 3)
                {
                    greenShip.IsAlive = false;
                    points += 3;
                }
               
            }

            //linking playerCharacter and playerBullet postions same
            if (!playerBullet.isFired)
            {
                playerBullet.Position = playerCharacter.Position;
            }
            if (playerBullet.Position.Y < 0)
            {
                playerBullet.isFired = false;
            }
            
            
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            //background
            Vector2 position = new Vector2(0, 0);
            _spriteBatch.Draw(background, position, Color.White);
            //text
            _spriteBatch.DrawString(font, "Score: " + points, new Vector2(0, 0), Color.White);
            //bulets
            _spriteBatch.Draw(playerBullet.Image, playerBullet.GetCentrePosition(), Color.White);
            //player
            _spriteBatch.Draw(playerCharacter.Image, playerCharacter.GetCentrePosition(), Color.White);
            //enemy ships
            //wave1
            _spriteBatch.Draw(blueShip.Image, blueShip.Position, Color.White);
            _spriteBatch.Draw(redShip.Image, redShip.Position, Color.White);
            _spriteBatch.Draw(blueShip2.Image, blueShip2.Position, Color.White);
            //wave2
            _spriteBatch.Draw(redShip2.Image, redShip2.Position, Color.White);
            _spriteBatch.Draw(greenShip.Image, greenShip.Position, Color.White);
            _spriteBatch.Draw(redShip3.Image, redShip3.Position, Color.White);


            _spriteBatch.Draw(rightBorder.Image, rightBorder.Position, Color.White);    
            _spriteBatch.Draw(leftBorder.Image, leftBorder.Position, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}