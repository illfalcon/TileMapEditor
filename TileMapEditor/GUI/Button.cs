using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileMapEditor.GUI
{
    public class Button
    {
        private Texture2D _image;
        private bool _clicked;
        private bool _prevClicked;
        private Vector2 _position;
        private Rectangle _collisionRectangle;

        public Action Click;

        public Button(Texture2D image, Vector2 position)
        {
            _image = image;
            _position = position;
            _collisionRectangle = new Rectangle((int)_position.X, (int)_position.Y, _image.Width, _image.Height);
        }

        public void Update()
        {
            MouseState mouseState = Mouse.GetState();
            Rectangle mousePos = new Rectangle(mouseState.Position.X, mouseState.Position.Y, 1, 1);

            if (mousePos.Intersects(_collisionRectangle) && mouseState.LeftButton == ButtonState.Pressed && !_prevClicked)
                Click?.Invoke();

            _prevClicked = _clicked;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_image, _position, Color.White);
        }
    }
}
