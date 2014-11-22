using System;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace Dodge
{
	public class Player
	{		
		private static SpriteUV sprite;
		private static TextureInfo textureInfo;
		private static Texture2D texture2D;
		private static Vector2 position;
		private Bounds2 boxBound;
		private static TouchStatus currentTouchStatus, previousTouchData;
		private static int screenHeight, screenWidth;
		private bool touching;
	
		private bool Alive;
		
		
		public Bounds2 Bounds {get{return boxBound;}}
		
			
		public Player (Scene scene)
		{
			
			textureInfo  = new TextureInfo("/Application/Assets/Box.png");
			
			sprite	 		= new SpriteUV();
			sprite 			= new SpriteUV(textureInfo);	
			sprite.Quad.S 	= textureInfo.TextureSizef;
			sprite.Position = new Vector2(500.0f,300.0f);
			position = new Vector2(500.0f, 300.0f);
			scene.AddChild(sprite);
			
			screenHeight = Director.Instance.GL.Context.GetViewport().Height;
			screenWidth = Director.Instance.GL.Context.GetViewport().Width;
			touching = false;
		}
		
		
		public void Dispose()
		{
			textureInfo.Dispose();

		}
		
		public void Update()
		{		
		
			List<TouchData> touches = Touch.GetData(0);
			foreach(TouchData data in touches)
			{
				currentTouchStatus = data.Status; // never gets used
				
				float xPos = (data.X +0.5f) * screenWidth;
				float yPos = screenHeight -((data.Y +0.5f) * screenHeight);
				
				if(data.Status == TouchStatus.Move)
				{
//					Console.WriteLine("x : " +  xPos);
//					Console.WriteLine("y : " +  yPos);
					position = new Vector2(xPos, yPos);
					touching = true;
	
				}
				else
					touching = false;
			}
			previousTouchData = currentTouchStatus; // never gets used
			sprite.Position = position;
			sprite.CenterSprite();

		}
		public bool isTouching()
		{
			return touching;
		}
		public bool Collision(Vector2 ePos, Vector2 eSize)
		{

			//Console.WriteLine(ePos.X);
			//Console.WriteLine(eSize);
			Bounds2 box = sprite.Quad.Bounds2();
			float width = box.Point11.X;
			float height = box.Point11.Y;
			if((position.X + width) < ePos.X - eSize.X)
				return false;
			else if(position.X - width > (ePos.X + eSize.X))
				return false;
			else if((position.Y + height) < ePos.Y - eSize.Y)
				return false;
			else if(position.Y - height > (ePos.Y + eSize.Y))
				return false;
			else 
				return true;
			
		}
	}
}

