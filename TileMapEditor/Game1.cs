using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using TileMapEditor.GUI;
using TileMapEditor.Helpers;
using TileMapEditor.MapThings;

namespace TileMapEditor
{
    public enum GameState { Active, Frozen }

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameState state;
        Map map;
        TileSet tileSet;
        //public static int mapHeight = 14;
        //public static int mapWidth = 100;
        //public static int tileHeight = 16;
        //public static int tileWidth = 16;

        public static int selectedTileNo = 1;

        public static Texture2D tileSheet;

        MouseState mouse;
        KeyboardState prevState;

        Button newMap;
        Button saveMap;
        Button loadMap;
        Button newTile;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
        }
        
        protected override void Initialize()
        {
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            graphics.ApplyChanges();
            Globals.ClientBounds = new Vector2(Window.ClientBounds.Width, Window.ClientBounds.Height);
            Globals.DrawOffset = Vector2.Zero;
            state = GameState.Active;
            map = new Map();
            tileSet = new TileSet();
            Globals.LeftView = new Viewport(0, 0, 500, 600);
            Globals.RightView = new Viewport(500, 0, 300, 600);
            base.Initialize();
        }
        
        //public void CreateNewMapWindow()
        //{
        //    var newMapWindow = new NewMapWindow();
        //    newMapWindow.Show();
        //}
        //
        //public void LoadMapWindow()
        //{
        //    var loadMapWindow = new LoadMapWindow();
        //    loadMapWindow.Show();
        //}
        //
        //public void SaveMapWindow()
        //{
        //    var saveMapWindow = new SaveMapWindow();
        //    saveMapWindow.Show();
        //}

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D newMapButton = Content.Load<Texture2D>("new");
            Texture2D saveMapButton = Content.Load<Texture2D>("save");
            Texture2D loadMapButton = Content.Load<Texture2D>("load");
            Texture2D tileSheetTexture = Content.Load<Texture2D>("jungletileset");
            map.Initialize(50, 14, 16, 16, tileSheetTexture, loadMapButton, newMapButton);
            tileSet.Initialize(tileSheetTexture, 16, 16, saveMapButton);

            newMap = new Button(newMapButton, new Vector2(20, Globals.ClientBounds.Y - newMapButton.Height));
            loadMap = new Button(loadMapButton, new Vector2(130, Globals.ClientBounds.Y - loadMapButton.Height));
            saveMap = new Button(saveMapButton, new Vector2(240, Globals.ClientBounds.Y - saveMapButton.Height));
            //newMap.Click += CreateNewMapWindow;
            //loadMap.Click += LoadMapWindow;
            //saveMap.Click += SaveMapWindow;
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState keyState = Keyboard.GetState();

            if (selectedTileNo < map.TileManager.Tiles.Length - 1)
            {
                if (keyState.IsKeyDown(Keys.Up) && !prevState.IsKeyDown(Keys.Up))
                    selectedTileNo++;
            }
            if (selectedTileNo > 1)
            {
                if (keyState.IsKeyDown(Keys.Down) && !prevState.IsKeyDown(Keys.Down))
                    selectedTileNo--;
            }

            prevState = keyState;

            if (state == GameState.Active && map.TileSheet != null)
            {
                map.SetTile(map.TileManager.Tiles[selectedTileNo]);
            }

            map.UpdateCamera();
            tileSet.Update();

            newMap.Update();
            loadMap.Update();
            saveMap.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            Viewport original = graphics.GraphicsDevice.Viewport;

            graphics.GraphicsDevice.Viewport = Globals.LeftView;
            GraphicsDevice.Clear(Color.FloralWhite);
            spriteBatch.Begin();
            map.Draw(spriteBatch);
            newMap.Draw(spriteBatch);
            loadMap.Draw(spriteBatch);
            saveMap.Draw(spriteBatch);
            spriteBatch.End();

            graphics.GraphicsDevice.Viewport = Globals.RightView;
            spriteBatch.Begin();
            tileSet.Draw(spriteBatch);
            spriteBatch.End();

            graphics.GraphicsDevice.Viewport = original;

            base.Draw(gameTime);
        }
    }
}
