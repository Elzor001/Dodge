using System;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;
namespace Dodge
{
	public class Tank : Enemy
	{

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
			
			speed = 800.0f;
			position = new Vector2(0.0f, 100.0f);
			//sprite.CenterSprite();
			sprite.Rotate((float)System.Math.PI);
			

		}
		public override Enemy Clone() { return new Tank(scene);}
		
		public override void Update(float dT)
		{
			if(sprite.Position.X - sprite.Quad.Bounds2().Point10.X > Director.Instance.GL.Context.GetViewport().Width)
			{
				setRandom();
			}
			else
				position.X +=speed*dT;
			
			sprite.Position = position;
			
		}
		public override void Draw(float dT)
		{
		}
		public void setRandom()
		{
			Random rand = new Random();
			position = new Vector2(0,(float)rand.NextDouble()* Director.Instance.GL.Context.GetViewport().Height);
			if(position.Y - sprite.Quad.Bounds2().Point01.Y < 0)
				position.Y = sprite.Quad.Bounds2().Point01.Y;

		}
	}
}

