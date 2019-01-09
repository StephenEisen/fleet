﻿using System.Linq;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Fleet.Managers;

namespace Fleet.Entity
{
	public class Enemy : Entity
	{
		Vector2 playerPosition;

    private float _life = 100;

		public Enemy(string filePath) : base(filePath) { }

		public override void Update(GameTime gameTime)
		{
			foreach (Entity player in GameManager.Instance.Entities.OfType<Player>())
			{
				playerPosition = player.position;
				break;
			}
      TurnToFace(playerPosition);
			position = Vector2.Lerp(position, playerPosition, 0.001f);
		}

		public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
		{
      spriteBatch.Draw(this.Texture, position, null, color, (rotation), origin, scale, SpriteEffects.None, 1);
    }

    private void TurnToFace(Vector2 location)
    {
      Vector2 _targetDirection = position - location;
      float _targetRotation = (float)Math.Atan2(_targetDirection.Y, _targetDirection.X);
      if (rotation < _targetRotation) //The scaler here can be replaced by a "turnspeed" in the future
        rotation += 0.1f;
      else if (rotation > _targetRotation)
        rotation -= 0.1f;
    }
	}
}
