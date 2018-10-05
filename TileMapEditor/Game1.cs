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
        Texture2D solid;
        Texture2D empty;

        public static int selectedTileNo = 0;

        Texture2D tileSheet;
        Texture2D selectedImage;

        MouseState mouse;
        KeyboardState prevState;

        MyButton newMap;
        MyButton saveMap;
        MyButton loadMap;
        MyButton newTile;

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

        public void OnNewMapClicked()
        {
            NewMapForm newMapForm = new NewMapForm();
            state = GameState.Frozen;
            newMapForm.ShowDialog();
            if (newMapForm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                map.Initialize(newMapForm.width, newMapForm.height, newMapForm.mapTileWidth, newMapForm.mapTileHeight, solid, empty);
                selectedTileNo = 0;
                Camera.Position = Vector2.Zero;
                if (tileSheet != null)
                {
                    tileSet.Initialize(tileSheet, newMapForm.mapTileWidth, newMapForm.mapTileHeight, selectedImage);
                    map.LoadTileSet(tileSheet);
                }
            }
            state = GameState.Active;
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
            solid = Content.Load<Texture2D>("load");
            empty = Content.Load<Texture2D>("save");
            selectedImage = Content.Load<Texture2D>("load");

            //tileSheet = Content.Load<Texture2D>("jungletileset");

            if (tileSheet != null)
                tileSet.Initialize(tileSheet, 16, 16, selectedImage);

            newMap = new MyButton(newMapButton, new Vector2(20, Globals.ClientBounds.Y - newMapButton.Height));
            loadMap = new MyButton(loadMapButton, new Vector2(130, Globals.ClientBounds.Y - loadMapButton.Height));
            saveMap = new MyButton(saveMapButton, new Vector2(240, Globals.ClientBounds.Y - saveMapButton.Height));
            newMap.Click += OnNewMapClicked;
            //loadMap.Click += LoadMapWindow;
            //saveMap.Click += SaveMapWindow;
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (state == GameState.Active)
            {

                KeyboardState keyState = Keyboard.GetState();

                if (map.TileManager != null && selectedTileNo < map.TileManager.Tiles.Length - 1)
                {
                    if (keyState.IsKeyDown(Keys.Up) && !prevState.IsKeyDown(Keys.Up))
                        selectedTileNo--;
                }
                if (map.TileManager != null && selectedTileNo > 1)
                {
                    if (keyState.IsKeyDown(Keys.Down) && !prevState.IsKeyDown(Keys.Down))
                        selectedTileNo++;
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
            }
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
            if (tileSheet != null)
            {
                tileSet.Draw(spriteBatch);
            }
            spriteBatch.End();

            graphics.GraphicsDevice.Viewport = original;

            base.Draw(gameTime);
        }
    }
}
