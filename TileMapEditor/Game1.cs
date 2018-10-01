using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TileMapEditor.GUI;

namespace TileMapEditor
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        RenderTarget2D mapTarget;
        RenderTarget2D tileSetTarget;

        int initial_screen_width = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width - 15;
        int initial_screen_height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - 80;

        Button newMap;
        Button saveMap;
        Button loadMap;
        Button newTile;

        public Game1()
        {
            // Set a display mode that is windowed but is the same as the desktop's current resolution (don't show a border)...
            // This is done instead of using true fullscreen mode since some firewalls will crash the computer in true fullscreen mode
            
            graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = initial_screen_width,
                PreferredBackBufferHeight = initial_screen_height,
                IsFullScreen = false,
                PreferredDepthStencilFormat = DepthFormat.Depth16
            };

            Content.RootDirectory = "Content";
        }
        
        protected override void Initialize()
        {
            double mapFieldWidth = initial_screen_width * 0.5;
            double mapFieldHeight = initial_screen_height * 0.5;
            mapTarget = new RenderTarget2D(GraphicsDevice, (int)mapFieldWidth, (int)mapFieldHeight);
            double tileSetFieldWidth = initial_screen_width * 0.25;
            double tileSetFieldHeight = initial_screen_height * 0.5;
            tileSetTarget = new RenderTarget2D(GraphicsDevice, (int)tileSetFieldWidth, (int)tileSetFieldHeight);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Texture2D newMapButton = Content.Load<Texture2D>("");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(mapTarget);
            GraphicsDevice.Clear(Color.CornflowerBlue);

            GraphicsDevice.SetRenderTarget(tileSetTarget);
            GraphicsDevice.Clear(Color.BurlyWood);

            GraphicsDevice.SetRenderTarget(null);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Opaque, SamplerState.LinearWrap, DepthStencilState.None, RasterizerState.CullNone);
            spriteBatch.Draw(mapTarget, new Vector2(initial_screen_width / 8, initial_screen_height / 8), Color.White);
            spriteBatch.Draw(tileSetTarget, new Vector2(initial_screen_width / 8 * 5, initial_screen_height / 8), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
