using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Example
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D myCharacter;
        Vector2 characterPosition = new Vector2(100, 100);
        float characterSpeed = 150;

        private SpriteFont font;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            myCharacter = Content.Load<Texture2D>("arrow");
            font = Content.Load<SpriteFont>("gameFont");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            KeyboardState kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Up))
            {
                characterPosition.Y -= characterSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Down))
            {
                characterPosition.Y += characterSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Left))
            {
                characterPosition.X -= characterSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Right))
            {
                characterPosition.X += characterSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            // Restrict the arrow to the screen
            if (characterPosition.X > _graphics.PreferredBackBufferWidth - myCharacter.Width / 2)
            {
                characterPosition.X = _graphics.PreferredBackBufferWidth - myCharacter.Width / 2;
            }
            else if (characterPosition.X < myCharacter.Width / 2)
            {
                characterPosition.X = myCharacter.Width / 2;
            }

            if (characterPosition.Y > _graphics.PreferredBackBufferHeight - myCharacter.Height / 2)
            {
                characterPosition.Y = _graphics.PreferredBackBufferHeight - myCharacter.Height / 2;
            }
            else if (characterPosition.Y < myCharacter.Height / 2)
            {
                characterPosition.Y = myCharacter.Height / 2;
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Vector2 fontDrawPos = new Vector2(300, 200);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(myCharacter, characterPosition - new Vector2(myCharacter.Width /2, myCharacter.Height / 2), Color.White);
            _spriteBatch.DrawString(font, "Hello World!", fontDrawPos, Color.Blue);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}