using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace Dodge
{
	public class EndGameScene : GameScene
	{
		private float timer;
		public EndGameScene ()
		{
			scene = new Sce.PlayStation.HighLevel.GameEngine2D.Scene();
			scene.Camera.SetViewFromViewport();
			
			textureInfo = new TextureInfo("/Application/Assets/endBackground.png");
			background = new SpriteUV(textureInfo);
			background.Quad.S = textureInfo.TextureSizef;
			scene.AddChild(background);
			timer = 0.0f;
		}
		public override void Update(float dT)
		{
			Touch.GetData(0).Clear();
			timer += dT;
			if(timer >= 2.0f)
			{
				SceneManager.Instance.setStartScene();
			}
			Director.Instance.Update();

		}
		public override void Draw(float dT)
		{
			Director.Instance.Render();
			Director.Instance.GL.Context.SwapBuffers();
			Director.Instance.PostSwap();
		}
	}
}

