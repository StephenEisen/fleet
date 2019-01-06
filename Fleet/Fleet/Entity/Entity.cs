﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Fleet.Entity
{
	public abstract class Entity
	{
		protected Texture2D Texture { get; private set; }

		public float Rotation;

		public Vector2 Position = Vector2.Zero;
		public Vector2 Velocity = Vector2.Zero;
		public Vector2 Acceleration = Vector2.Zero;

		public float TurnAcceleration;


		public Entity(Texture2D texture)
		{
			this.Texture = texture;
		}

		public abstract void Update(GameTime gameTime);

		public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);
	}
}
