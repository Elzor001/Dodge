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
	
		private bool Alive;
		
		
		public Bounds2 Bounds {get{return boxBound;}}
		
			
		public Player (Scene scene)
		{
			
			textureInfo  = new TextureInfo("/Application/Assets/Box.png");
			
			sprite	 		= new SpriteUV();
			sprite 			= new SpriteUV(textureInfo);	
			sprite.Quad.S 	= textureInfo.TextureSizef;
			sprite.Position = new Vector2(0.0f,0.0f);
			
			scene.AddChild(sprite);
			
		}
		
		
		public void Dispose()
		{
			textureInfo.Dispose();

		}
		
		public void Update()
		{
			TouchData touches = Touch.GetData(0);
			
				currentTouchStatus = touches.Status;
				float xPos = (touches.X +0.5f) * Director.Instance.GL.Context.GetViewport().Width;
				float yPos = (touches.Y +0.5f) * Director.Instance.GL.Context.GetViewport().Height;
				
				if(touches.Status == TouchStatus.Down)
				{
					
					
					position = new Vector2(xPos, yPos);
					
					
					
					
					
				}
				
				
			
		
//		List<TouchData> touches = Touch.GetData(0);
//			foreach(TouchData data in touches)
//			{
//				currentTouchStatus = data.Status;
//				float xPos = (data.X +0.5f) * Director.Instance.GL.Context.GetViewport().Width;
//				float yPos = (data.Y +0.5f) * Director.Instance.GL.Context.GetViewport().Height;
//				
//				if(data.Status == TouchStatus.Down)
//				{
//					
//					
//					position = new Vector2(xPos, yPos);
//					
//					
//					
//					
//					
//				}
//				
//				
//			}
			sprite.Position = position;
		
				
				
			
			
		}
		
		public bool Collision()
		{
			//if(boxBound.Overlaps (/*Enemy bounds*/))
			   return true;
			   
			   return false;
			
		}
	}
}

