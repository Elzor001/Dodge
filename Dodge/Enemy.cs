using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace Dodge
{
	public class Enemy
	{
		private static SpriteTile sprite;
		private static TextureInfo textureInfo;
		private static Texture2D texture2D;
		private static Vector2 position;
		private static Vector2i numTiles, tiles;
		private static int test;
		private static bool testC;
		
		
		public Enemy (Scene scene)
		{
			numTiles = new Vector2i(6,3);
			tiles = new Vector2i(0,2);
			texture2D = new Texture2D("/Application/Assets/Flying_Fish2.png", false);
			textureInfo = new TextureInfo(texture2D, numTiles);

			sprite = new SpriteTile(textureInfo);
			sprite.Quad.S = new Vector2(150.0f, 150.0f);
			
			sprite.TileIndex2D = tiles;
			scene.AddChild(sprite);
			position = new Vector2(100.0f, 150);
			
			test = 0;
			testC = false;

			
		}
		public void Update()
		{
			position.X-= 5.0f;
			if(position.X < 0)
				position.X = Director.Instance.GL.Context.GetViewport().Width;
			sprite.Position = position;
		}
		public void Draw()
		{
			test++;

			if(test > 1)
			{
				if(!testC)
					tiles.X++;
				else
					tiles.X--;
				if(tiles.X >= 5)
				{
					testC = true;
					
				}
				if(tiles.X == 0)
				{
					testC = false;
				}
				test = 0;
			}

			sprite.TileIndex2D = tiles;
		}
	}
}

