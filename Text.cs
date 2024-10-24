﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace MonoLibrary
{
    internal class Text
    {
        private SpriteFont font;
        private string text;
        private Vector2 position;
        private Color color;

        internal Text(SpriteFont font, string text, Vector2 position, Color color)
        {
            this.font = font;
            this.text = text;
            this.position = position;
            this.color = color;
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            Vector2 center = font.MeasureString(text) / 2;
            spriteBatch.DrawString(
                font, 
                text, 
                position, 
                Color.White,
                0,
                center,
                1f, // scale
                SpriteEffects.None,
                0.5f);
        }
    }
}
