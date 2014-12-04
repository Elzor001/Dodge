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
		private TextureInfo boxtex1, boxtex2;
		private int screenWidth, screenHeight;
		
		public StartScene ()
		{
			scene = new Sce.PlayStation.HighLevel.GameEngine2D.Scene();
			scene.Camera.SetViewFromViewport();
			
			textureInfo = new TextureInfo("/Application/Assets/MenuStart.png");
			background = new SpriteUV(textureInfo);
			background.Quad.S = textureInfo.TextureSizef;
			scene.AddChild(background);
			
			boxtex1 = new TextureInfo("/Application/Assets/playBtn.png");
			boxtex2 = new TextureInfo("/Application/Assets/Scorescrn.png");
			
			btn1 = new SpriteUV(boxtex1);
			btn1.Quad.S = new Vector2(boxtex1.TextureSizef.X, boxtex1.TextureSizef.Y);
			btn1.Position = new Vector2(150,110);
			
			btn2 = new SpriteUV(boxtex2);
			btn2.Quad.S = new Vector2(boxtex2.TextureSizef.X, boxtex2.TextureSizef.Y);
			btn2.Position = new Vector2(500,110);
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

