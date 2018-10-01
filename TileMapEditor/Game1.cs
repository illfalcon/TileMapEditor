using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using TileMapEditor.GUI;
using TileMapEditor.MapThings;

namespace TileMapEditor
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        RenderTarget2D mapTarget;
        RenderTarget2D tileSetTarget;

        Map map;

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
            IsMouseVisible = true;

            double mapFieldWidth = initial_screen_width * 0.5;
            double mapFieldHeight = initial_screen_height * 0.5;
            mapTarget = new RenderTarget2D(GraphicsDevice, (int)mapFieldWidth, (int)mapFieldHeight);
            double tileSetFieldWidth = initial_screen_width * 0.25;
            double tileSetFieldHeight = initial_screen_height * 0.5;
            tileSetTarget = new RenderTarget2D(GraphicsDevice, (int)tileSetFieldWidth, (int)tileSetFieldHeight);
            base.Initialize();
        }
        
        public void CreateNewMapWindow()
        {
            var newMapWindow = new NewMapWindow();
            newMapWindow.Show();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D newMapButton = Content.Load<Texture2D>("new");
            Texture2D saveMapButton = Content.Load<Texture2D>("save");
            Texture2D loadMapButton = Content.Load<Texture2D>("load");

            newMap = new Button(newMapButton, new Vector2(initial_screen_width / 8, initial_screen_height / 8 * 5));
            newMap.Click += CreateNewMapWindow;
            //loadMap = new Button(loadMapButton, new Vector2(initial_screen_width / 8, initial_screen_height / 8 * 5));
            //saveMap = new Button(saveMapButton, new Vector2(initial_screen_width / 8, initial_screen_height / 8 * 5));
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            newMap.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(mapTarget);
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            map?.Draw(spriteBatch);
            spriteBatch.End();
            

            GraphicsDevice.SetRenderTarget(tileSetTarget);
            GraphicsDevice.Clear(Color.BurlyWood);

            GraphicsDevice.SetRenderTarget(null);

            GraphicsDevice.Clear(Color.FloralWhite);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Opaque, SamplerState.LinearWrap, DepthStencilState.None, RasterizerState.CullNone);
            spriteBatch.Draw(mapTarget, new Vector2(initial_screen_width / 8, initial_screen_height / 8), Color.White);
            spriteBatch.Draw(tileSetTarget, new Vector2(initial_screen_width / 8 * 5, initial_screen_height / 8), Color.White);
            newMap.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
