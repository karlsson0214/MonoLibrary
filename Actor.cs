﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace MonoLibrary
{
    /// <summary>
    /// An Actor is an objekt in the game world.
    /// 
    /// Inherit Actor to design objekt to your world.
    /// 
    /// An inheriting class must implement the Update method.
    /// </summary>
    public abstract class Actor
    {
        private Texture2D image;
        private Vector2 position;
        // rotation in degrees
        // 0 = right, 90 = down, 180 = left, 270 = up
        private float rotation;
        private World world;

        public Actor()
        {
            rotation = 0;
        }
        /// <summary>
        /// Get the world this actor lives in.
        /// </summary>
        public  World World
        {
            get { return world; }
            internal set { world = value; }
        }
        /// <summary>
        /// Set or get the image for this actor.
        /// </summary>
        public Texture2D Image
        {
            get { return image; }
            set { image = value; }
        }
        /// <summary>
        /// Set or get the position for this actor in the world.
        /// </summary>
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        /// <summary>
        /// Get the actors radius.
        /// </summary>
        public float Radius
        {
            get
            {
                return (image.Width + image.Height) / 4;
            }
        }
        /// <summary>
        /// Set or get the rotation of this actor.
        /// </summary>
        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }





        /// <summary>
        /// Called once per frame to draw actor to the screen.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw the actor, centered on the position.
            spriteBatch.Draw(image,
                position,
                null,
                Color.White,
                rotation * MathF.PI / 180f, // Convert to radians
                new Vector2(image.Width / 2, image.Height / 2), // Center image on position
                Vector2.One,
                SpriteEffects.None,
                0f);
        }
        /// <summary>
        /// Get one actor of the specified type. 
        /// Returns null if no intersecting actor was found.
        /// 
        /// Example:
        /// 
        /// GetOneIntersectingActor(typeof(ClassName))
        /// </summary>
        /// <param name="actorType"></param>
        /// <returns></returns>
        public Actor GetOneIntersectingActor(Type actorType)
        {
            List<Actor> actorsOfType = world.actors[actorType];
            foreach (var actor in actorsOfType)
            {
                if (Intersects(actor))
                {
                    return actor;
                }
            }
            return null;
        }
        /// <summary>
        /// Move the actor in the direction it is facing.
        /// </summary>
        /// <param name="distance">distance in pixels</param>
        public void Move(float distance)
        {
            var direction = new Vector2((float)Math.Cos(MathHelper.ToRadians(rotation)), (float)Math.Sin(MathHelper.ToRadians(rotation)));
            position += direction * distance;
        }
        /// <summary>
        /// Returns true if this actor intersects with the other actor, 
        /// otherwise false.
        /// </summary>
        /// <param name="otherActor"></param>
        /// <returns></returns>
        public bool Intersects(Actor otherActor)
        {
            return Vector2.Distance(position, otherActor.Position) < Radius + otherActor.Radius;
        }
        /// <summary>
        /// Set the x-coordinate for this actor.
        /// </summary>
        /// <param name="x"></param>
        public void SetX(float x)
        {
            position.X = x;
        }
        /// <summary>
        /// Set the y-coordinate for this actor.
        /// </summary>
        /// <param name="y"></param>
        public void SetY(float y)
        {
            position.Y = y;
        }
        /// <summary>
        /// Turn this actor towards the specified coordinate.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void TurnTowards(float x, float y)
        {
            Vector2 directionToOther = new Vector2(x, y) - Position;
            rotation = VectorToAngleInDegrees(directionToOther);
        }

        /// <summary>
        /// override this method in an enheriting class. 
        /// Implement game logic in the overriding method.
        /// </summary>
        /// <param name="gameTime"></param>
        public abstract void Update(GameTime gameTime);

        private float VectorToAngleInDegrees(Vector2 direction)
        {
            float angleInRadians = (float)Math.Atan2(direction.Y, direction.X);
            return MathHelper.ToDegrees(angleInRadians);
        }

    }
}
