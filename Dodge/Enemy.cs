
using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace Dodge
{
	public abstract class Enemy
	{
		protected SpriteTile sprite;
		protected TextureInfo textureInfo;
		protected Texture2D texture2D;
		protected Vector2 position;
		protected Vector2i numTiles, tiles;
		protected float speed;
		protected Scene scene;

		public Enemy ()
		{
		}
		public abstract Enemy Clone();
		public virtual void Update(float dT){}
		public virtual void Draw(float dT){}
		
	}
}

