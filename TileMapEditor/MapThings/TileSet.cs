using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileMapEditor.Helpers;

namespace TileMapEditor.MapThings
{
    public class TileSet
    {
        private Texture2D _tileSheet;
        private int _tileWidth;
        private int _tileHeight;
        private int _tilesHigh;
        private int _tilesWide;
        private Rectangle _selected;
        private Texture2D _selectedImage;

        public int Width { get { return _tileSheet.Width; } }
        public int Height { get { return _tileSheet.Height; } }
        public Rectangle Selected { get { return _selected; } }

        public void Initialize(Texture2D tileSheet, int tileWidth, int tileHeight, Texture2D selectedImage)
        {
            _tileSheet = tileSheet;
            _tileWidth = tileWidth;
            _tileHeight = tileHeight;
            _tilesHigh = Height / _tileHeight;
            _tilesWide = Width / _tileWidth;
            _selected = Rectangle.Empty;
            _selectedImage = selectedImage;
        }

        public Rectangle SelectImage(Vector2 mouseCoords)
        {
            Vector2 tileCoords = GetTileFromCoordinates(mouseCoords.X - Globals.RightView.X - Globals.DrawOffset.X, mouseCoords.Y - Globals.RightView.Y - Globals.DrawOffset.Y);

            return new Rectangle((int)tileCoords.X * _tileWidth, (int)tileCoords.Y * _tileHeight, _tileWidth, _tileHeight);
        }

        public Vector2 GetTileFromCoordinates(float wX, float wY)
        {
            int mX = (int)(wX / _tileWidth);
            int mY = (int)(wY / _tileHeight);
            return new Vector2(mX, mY);
        }

        public void UpdateInput()
        {
            KeyboardState keys = Keyboard.GetState();
            if (keys.IsKeyDown(Keys.NumPad8))
                Globals.DrawOffset = new Vector2(Globals.DrawOffset.X, Globals.DrawOffset.Y - 1);
            if (keys.IsKeyDown(Keys.NumPad2))
                Globals.DrawOffset = new Vector2(Globals.DrawOffset.X, Globals.DrawOffset.Y + 1);
            if (keys.IsKeyDown(Keys.NumPad4))
                Globals.DrawOffset = new Vector2(Globals.DrawOffset.X - 1, Globals.DrawOffset.Y);
            if (keys.IsKeyDown(Keys.NumPad6))
                Globals.DrawOffset = new Vector2(Globals.DrawOffset.X + 1, Globals.DrawOffset.Y);
        }

        public void Update()
        {
            UpdateInput();

            Rectangle mouseRect;
            Rectangle viewPort;

            MouseState curMouseState = Mouse.GetState();
            mouseRect = new Rectangle(curMouseState.X, curMouseState.Y, 1, 1);
            viewPort = new Rectangle(Globals.RightView.X, Globals.RightView.Y, Globals.RightView.Width, Globals.RightView.Height);
            if (mouseRect.Intersects(viewPort) && 
                curMouseState.X - Globals.RightView.X < Width + Globals.DrawOffset.X &&
                curMouseState.X - Globals.RightView.X > Globals.DrawOffset.X &&
                curMouseState.Y - Globals.RightView.Y < Height + Globals.DrawOffset.Y &&
                curMouseState.Y - Globals.RightView.Y > Globals.DrawOffset.Y)
            {
                _selected = SelectImage(new Vector2(curMouseState.X, curMouseState.Y));
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 offset = new Vector2(Globals.DrawOffset.X, Globals.DrawOffset.Y);

            spriteBatch.Draw(_tileSheet, offset, Color.White);
            spriteBatch.Draw(_selectedImage, new Rectangle((int)(_selected.X + Globals.DrawOffset.X), (int)(_selected.Y + Globals.DrawOffset.Y), _tileWidth, _tileHeight), new Color(255, 0, 0, 50));
        }
    }
}
