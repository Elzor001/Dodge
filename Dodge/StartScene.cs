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
		
		private SpriteUV btn1, btn2;
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
			
			btn1 = new SpriteUV(boxtex);
			btn1.Quad.S = new Vector2(boxtex.TextureSizef.X * 4.4f, boxtex.TextureSizef.Y*2.7f);
			btn1.Position = new Vector2(205,140);
			
			btn2 = new SpriteUV(boxtex);
			btn2.Quad.S = new Vector2(boxtex.TextureSizef.X * 4.4f, boxtex.TextureSizef.Y*2.7f);
			btn2.Position = new Vector2(515,145);
			scene.AddChild(btn1);
			scene.AddChild(btn2);
			
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
				if(pressBtn(btn1, x, y))
					SceneManager.Instance.setInGameScene();
				if(pressBtn(btn2, x, y))
					SceneManager.Instance.setHighscoreScene();
			}
			Director.Instance.Update();
			
		}
		public bool pressBtn(SpriteUV btn, float x, float y)
		{
			
			Bounds2 boxb = btn.Quad.Bounds2();
			float width = boxb.Point11.X;
			float height = boxb.Point11.Y;
			if((btn.Position.X) > x)
				return false;
			else if(btn.Position.X + width < x)
				return false;
			else if((btn.Position.Y) > y)
				return false;
			else if(btn.Position.Y + height < y)
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

