using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MonoLibrary
{
    /// <summary>
    /// Class used to load game art.
    /// </summary>
    public class GameArt
    {
        private static Dictionary<string, Texture2D> images  = new Dictionary<string, Texture2D>();
        private static ContentManager content;
        
        /// <summary>
        /// Set contentmanager. 
        /// </summary>
        /// <param name="content"></param>
        internal static void SetContentManager(ContentManager content)
        {
            GameArt.content = content;
        }
        /// <summary>
        /// Add an image file. Use the file name.
        /// </summary>
        /// <param name="name"></param>
        public static void Add(string name)
        {
            if (content == null)
            {
                throw new Exception("ContentManager not set to a value. Call SetContentManager.");
            }
            images[name] = content.Load<Texture2D>(name);
        }
        /// <summary>
        /// Add several images. Use filenames stored in an array.
        /// </summary>
        /// <param name="names"></param>
        public static void Add(string[] names)
        {
            foreach (string name in names)
            {
                Add(name);
            }

        }

        public static Texture2D Get(string name) 
        { 
            return images[name]; 
        }
    }
}
