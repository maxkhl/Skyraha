﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2
{
    /// <summary>
    /// Ship Class Definition for constructing, drawing and updating the Ships
    /// </summary>
    class Ship : DrawableGameComponent
    {
        #region Public Variables
        /// <summary>
        /// The ships name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Points of this ship
        /// </summary>
        public int Points { get; private set; }

        /// <summary>
        /// Healthpoints of the ship
        /// </summary>
        public int Life { get; private set; }

        /// <summary>
        /// Position of the ship
        /// </summary>
        public Vector2 Position { get; private set; }
        #endregion

        #region Private Variables
        /// <summary>
        /// Maximum speed of the ship
        /// </summary>
        private float _Speed = 4;

        /// <summary>
        /// Texture of this ship
        /// </summary>
        private Texture2D _Texture;
        #endregion

        #region Constructors
        /// <summary>
        /// Ship Constructor, for creating Ships and setting the parameters.
        /// </summary>
        /// <param name="Name">Name of the new</param>
        /// <param name="Position">Start Position</param>
        /// <param name="Life">Ships initial healthpoints</param>
        public Ship(Skyraha Game, string Name, Vector2 Position, int Life = 100) : base(Game)
        {
            // Announce gameobject to maingame
            Game.Components.Add(this);

            // Set initial values
            this.Name = Name;
            this.Life = Life;

            // Load default ship-texture
            this._Texture = Game.Content.Load<Texture2D>("Jäger");

            // Calculate ship position based on texture size
            this.Position = Position - new Vector2(_Texture.Width, _Texture.Height) / 2;


        }
        #endregion

        #region Draw Method
        /// <summary>
        /// Drawing the ship with the given parameters
        /// </summary>
        /// <param name="gameTime">Current time in the draw-loop</param>
        public override void Draw(GameTime gameTime)
        {
            // Draw this ship
            ((Skyraha)this.Game).spriteBatch.Draw(
                _Texture,
                new Rectangle(
                    (int)Position.X,
                    (int)Position.Y,
                    _Texture.Width,
                    _Texture.Height),
                (Color.White));

            base.Draw(gameTime);
        }
        #endregion

        #region Update Method
        /// <summary>
        /// Updater, keeps the position etc. up to date
        /// </summary>
        /// <param name="gameTime">Current time in the update-loop</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        #endregion

        #region Other Methods
        /// <summary>
        /// Adds points to this ship
        /// </summary>
        /// <param name="Amount">Amount of added points</param>
        public void AddPoints(int Amount)
        {
            Points += Amount;
        }

        /// <summary>
        /// Death Function, kills the Ship if his life points reach zero
        /// </summary>
        public void Kill()
        {
            // Healthpoints cant go into negative
            if (Life > 0)
            {
                Life = 0;
            }
        }
        #endregion
    }
}

