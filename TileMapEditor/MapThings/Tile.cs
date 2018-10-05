using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileMapEditor.MapThings
{
    public class Tile
    {
        public Rectangle SourceRectangle { get; set; }
        public Rectangle CollisionRectangle { get; set; }
        public bool IsGround { get; set; }
        public bool IsSolid { get; set; }
        public bool IsEmpty { get; set; }
        public bool IsOneWay { get; set; }

        public Tile(bool isGround, bool isSolid, bool isEmpty, bool isOneWay, Rectangle srcRect, Rectangle colRect)
        {
            IsGround = isGround;
            IsSolid = isSolid;
            IsEmpty = isEmpty;
            IsOneWay = isOneWay;
            SourceRectangle = srcRect;
            CollisionRectangle = colRect;
        }
    }
}
