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
		private Label scoreTxt;
		public EndGameScene ()
		{
			scene = new Sce.PlayStation.HighLevel.GameEngine2D.Scene();
			scene.Camera.SetViewFromViewport();
			
			textureInfo = new TextureInfo("/Application/Assets/endBackground.png");
			background = new SpriteUV(textureInfo);
			background.Quad.S = textureInfo.TextureSizef;
			scene.AddChild(background);
			timer = 0.0f;
			
			scoreTxt = new Label();
			scoreTxt.Text = "Score: " + ScoreManager.Instance.getScore();
			scoreTxt.Scale = new Vector2(5.0f, 5.0f);
			scoreTxt.Position = new Vector2(Director.Instance.GL.Context.GetViewport().Width/2 - 150, Director.Instance.GL.Context.GetViewport().Height*0.1f);
			scoreTxt.Color = new Vector4(0.0f, 1.0f, 0.0f, 1.0f);
			
			scene.AddChild(scoreTxt);
			
			ScoreManager.Instance.reset();
		}
		public override void Update(float dT)
		{
			var touches = Touch.GetData(0);
			timer += dT;
			if(touches.Count > 0 && touches[0].Status == TouchStatus.Down || timer >= 5.0f)
			{
				SceneManager.Instance.setStartScene();
			}
			Director.Instance.Update();

		}

	}
}

