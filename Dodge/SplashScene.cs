using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;
using Sce.PlayStation.Core.Imaging;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;
using Sce.PlayStation.HighLevel.UI;

namespace Dodge
{
	public class SplashScene : GameScene
	{
		private SpriteUV splat, title;
		private TextureInfo splatTex, titleTex;
		private Vector2 splatScale, titleScale;
		private float timer, speed;
		
		public SplashScene ()
		{
			scene = new Sce.PlayStation.HighLevel.GameEngine2D.Scene();
			scene.Camera.SetViewFromViewport();
			
			textureInfo = new TextureInfo("/Application/Assets/Splashscreen1.png");
			background = new SpriteUV(textureInfo);
			background.Quad.S = textureInfo.TextureSizef;
			scene.AddChild(background);
			splatScale = new Vector2(10.0f, 10.0f);
			titleScale = new Vector2(10.0f, 10.0f);
			splatTex = new TextureInfo("/Application/Assets/splat.png");
			titleTex = new TextureInfo("/Application/Assets/splattxt.png");
			splat = new SpriteUV(splatTex);
			splat.Quad.S = splatTex.TextureSizef;
			splat.Position = new Vector2(Director.Instance.GL.Context.GetViewport().Width/3, Director.Instance.GL.Context.GetViewport().Height/7);
			title = new SpriteUV(titleTex);
			title.Quad.S = titleTex.TextureSizef;
			title.Position = new Vector2(Director.Instance.GL.Context.GetViewport().Width/3.5f, Director.Instance.GL.Context.GetViewport().Height/2.8f);
			
			scene.AddChild(splat);
			scene.AddChild(title);
			splat.Scale = splatScale;
			title.Scale = titleScale;
			splat.Color = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
			title.Color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
			speed = 1.0f;
		}
		public override void Update(float dT)
		{
			var touches = Touch.GetData(0);
			timer += dT;
			if(timer > 0.5f)
			{
				splat.Color = new Vector4(0.0f, 0.0f, 0.0f, 1.0f);
				ScaleSplat( dT);
			}	
			if(timer >2.5f)
			{	
				ScaleTitle(dT);
				if(timer > 3.0f)
					title.Color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
			}
			
			if(touches.Count > 0 && touches[0].Status == TouchStatus.Down || timer >= 8.0f)
			{
				SceneManager.Instance.setStartScene();
			}
			Director.Instance.Update();
		}
		private void ScaleSplat(float dT)
		{
			if(speed < 9.0f)
				speed += 0.5f;
			if(splatScale.X > 1.0f)
				splatScale.X -=speed*dT;
			if(splatScale.Y > 1.0f)
				splatScale.Y -=speed*dT;
			
			splat.Scale = splatScale;
		}
		private void ScaleTitle(float dT)
		{
			if(titleScale.X >1.0f)
				titleScale.X -=5.0f*dT;
			if(titleScale.Y > 1.0f)
				titleScale.Y -=5.0f*dT;
			
			title.Scale = titleScale;
		}
	}
}

