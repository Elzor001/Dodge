using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace Dodge
{
	public class StartScene : GameScene
	{
		
		private SpriteUV box;
		private TextureInfo boxtex;
		private int screenWidth, screenHeight;
		
		public StartScene ()
		{
			scene = new Sce.PlayStation.HighLevel.GameEngine2D.Scene();
			scene.Camera.SetViewFromViewport();
			
			textureInfo = new TextureInfo("/Application/Assets/startBackground.png");
			background = new SpriteUV(textureInfo);
			background.Quad.S = textureInfo.TextureSizef;
			scene.AddChild(background);
			
			boxtex = new TextureInfo("/Application/Assets/box2.png");
			
			box = new SpriteUV(boxtex);
			box.Quad.S = new Vector2(boxtex.TextureSizef.X * 4.4f, boxtex.TextureSizef.Y*2.7f);
			box.Position = new Vector2(205,140);
			scene.AddChild(box);
			
			screenWidth = Director.Instance.GL.Context.GetViewport().Width;
			screenHeight = Director.Instance.GL.Context.GetViewport().Height;
		}
		public override void Update(float dT)
		{
			var touches = Touch.GetData(0);
			if(touches.Count > 0 && touches[0].Status == TouchStatus.Down)
			{
				float x = (touches[0].X +0.5f) * screenWidth;
				float y = screenHeight -((touches[0].Y +0.5f) * screenHeight);
				if(pressBtn1(x, y))
					SceneManager.Instance.setInGameScene();
			}
			Director.Instance.Update();
			
		}
		public bool pressBtn1(float x, float y)
		{
			
			Bounds2 boxb = box.Quad.Bounds2();
			float width = boxb.Point11.X;
			float height = boxb.Point11.Y;
			if((box.Position.X) > x)
				return false;
			else if(box.Position.X + width < x)
				return false;
			else if((box.Position.Y) > y)
				return false;
			else if(box.Position.Y + height < y)
				return false;
			else 
				return true;

		}
		public override void Draw(float dT)
		{
			Director.Instance.Render();
			Director.Instance.GL.Context.SwapBuffers();
			Director.Instance.PostSwap();
		}
	}
}

