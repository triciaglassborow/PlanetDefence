using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        private RedEnemy redShip;
        private GreenEnemy greenShip;
        private Walls rightBorder;
        private Walls leftBorder;
        private Projectile playerBullet;

        public int points = 0;

        //public Rectangle RBorder = new((int)0, (int)-100, (int)1, (int)864);
        //public Rectangle LBorder = new((int)552, (int)-100, (int)1, (int)864);

        
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

            blueShip = new BlueEnemy(1,0)
            {
                Image = blueEnemy
            };

            redShip = new RedEnemy(100,0)
            {
                Image = redEnemy
            };

            greenShip = new GreenEnemy(200,0)
            {
                Image = greenEnemy
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

            playerCharacter.Update(gameTime);
            blueShip.Update(gameTime);
            redShip.Update(gameTime);
            greenShip.Update(gameTime);
            rightBorder.Update(gameTime);
            leftBorder.Update(gameTime);
            playerBullet.Update(gameTime);
            base.Update(gameTime);

            //collisions

            //player collising wth enemy ship ends the game, brings up death screen
            if (playerCharacter.HasCollided(blueShip))
            {
                //death screen
            }
            if (playerCharacter.HasCollided(redShip))
            {
                //redShip.IsAlive = false;
                //death screen
            }
            if (playerCharacter.HasCollided(greenShip))
            {
                //death screen
            }

            //enemys hitting right border

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
                points++;
                redShip.lives++;
                if (redShip.lives == 2)
                {
                    redShip.IsAlive = false;
                }
                
                
            }
            if (playerBullet.HasCollided(greenShip))
            {
                playerBullet.isFired = false;
                points++;
                greenShip.lives++;
                if (greenShip.lives == 3)
                {
                    greenShip.IsAlive = false;
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
            _spriteBatch.Draw(blueShip.Image, blueShip.Position, Color.White);
            _spriteBatch.Draw(redShip.Image, redShip.Position, Color.White);
            _spriteBatch.Draw(greenShip.Image, greenShip.Position, Color.White);



            _spriteBatch.Draw(rightBorder.Image, rightBorder.Position, Color.White);    
            _spriteBatch.Draw(leftBorder.Image, leftBorder.Position, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}