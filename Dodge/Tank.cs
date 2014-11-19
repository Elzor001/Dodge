using System;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;
namespace Dodge
{
	public class Tank : Enemy
	{
		private Random rand = new Random();
		private bool leftRight;
		public Tank (Scene scene)
		{
			
			numTiles = new Vector2i(1,1); // tiles in the sprite sheet
			tiles = new Vector2i(0,0); // tile you are displaying
			texture2D = new Texture2D("/Application/Assets/E-100_preview.png", false);
			textureInfo = new TextureInfo(texture2D, numTiles);

			sprite = new SpriteTile(textureInfo);

			sprite.Quad.S = textureInfo.TextureSizef;
			sprite.TileIndex2D = tiles; // sets which tile you are viewing
			scene.AddChild(sprite);
			
			speed = (float)SceneManager.Instance.rand.NextDouble()* 800.0f;
			position = new Vector2(0.0f, 100.0f);
			setRandom();
			//sprite.CenterSprite();
			
			
			if(SceneManager.Instance.rand.NextDouble() > 0.5)
			{
				leftRight = true;
				sprite.Rotate((float)System.Math.PI);
			}
			else
				leftRight = false;


		}
		public override Enemy Clone() { return new Tank(scene);}
		
		public override void Update(float dT)
		{
			if(leftRight)
			{
				if(sprite.Position.X - sprite.Quad.Bounds2().Point10.X > Director.Instance.GL.Context.GetViewport().Width)
				{
					setRandom();
				}
				else
					position.X +=speed*dT;
			}
			else
			{
				if(sprite.Position.X + sprite.Quad.Bounds2().Point10.X < 0)
				{
					setRandom();
				}
				else
					position.X -=speed*dT;
			}
			sprite.Position = position;
			
		}
		public override void Draw(float dT)
		{
		}
		public void setRandom()
		{
			if(leftRight)
			{
				position = new Vector2(0, (float)SceneManager.Instance.rand.NextDouble()* Director.Instance.GL.Context.GetViewport().Height);
				if(position.Y - sprite.Quad.Bounds2().Point01.Y < 0)
					position.Y = sprite.Quad.Bounds2().Point01.Y;
			}
			else
			{
				position = new Vector2(Director.Instance.GL.Context.GetViewport().Width, (float)SceneManager.Instance.rand.NextDouble()* Director.Instance.GL.Context.GetViewport().Height);
				if(position.Y - sprite.Quad.Bounds2().Point01.Y < 0)
					position.Y = sprite.Quad.Bounds2().Point01.Y;
			}
			speed = (float)SceneManager.Instance.rand.Next(500,800);

		}
	}
}

