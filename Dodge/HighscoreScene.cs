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
	public class HighscoreScene: GameScene
	{
		private Sce.PlayStation.HighLevel.UI.Scene uiScene;
		private Sce.PlayStation.HighLevel.UI.Label uiScore1, uiScore2, uiScore3, uiScore4, uiScore5;
		private List<int> scores;

		
		public HighscoreScene ()
		{
			scene = new Sce.PlayStation.HighLevel.GameEngine2D.Scene();
			scene.Camera.SetViewFromViewport();
			
			textureInfo = new TextureInfo("/Application/Assets/Highscore.png");
			background = new SpriteUV(textureInfo);
			background.Quad.S = textureInfo.TextureSizef;
			scene.AddChild(background);
			
			InitializeUI();
			setScore();
		}
		
		private void InitializeUI()
		{
			uiScene = new Sce.PlayStation.HighLevel.UI.Scene();
			Panel panel = new Panel();
			panel.Width = Director.Instance.GL.Context.GetViewport().Width;
			panel.Height = Director.Instance.GL.Context.GetViewport().Height;
			
			initScore ();			
			panel.AddChildLast(uiScore1);
			panel.AddChildLast(uiScore2);
			panel.AddChildLast(uiScore3);
			panel.AddChildLast(uiScore4);
			panel.AddChildLast(uiScore5);			
			uiScene.RootWidget.AddChildLast(panel);
			UISystem.SetScene(uiScene);
		}
		private void setScore()
		{
			scores = ScoreManager.Instance.getScores();
			scores.Sort();
			scores.Reverse();
			int[] sceneScores = {0, 0, 0, 0,0};
			
			int count = 5;
			if(scores.Count >= 0 && scores.Count <5)
				count = scores.Count;
			for (int i = 0; i < count; i++) 
			{
				sceneScores[i] = scores[i];
			}
			
			uiScore1.Text = "1st Score: " + sceneScores[0];
			uiScore2.Text = "2nd Score: " + sceneScores[1];
			uiScore3.Text = "3rd Score: " + sceneScores[2];
			uiScore4.Text = "4th Score: " + sceneScores[3];
			uiScore5.Text = "5th Score: " + sceneScores[4];
		}
		public override void Update(float dT)
		{
			var touches = Touch.GetData(0);
			if(touches.Count > 0 && touches[0].Status == TouchStatus.Down)
				SceneManager.Instance.setStartScene();
			Director.Instance.Update();
		}
		public override void Draw(float dT)
		{
			Director.Instance.Render();
			UISystem.Render();
			Director.Instance.GL.Context.SwapBuffers();
			Director.Instance.PostSwap();
		}
		private void initScore()
		{
			uiScore1 = new Sce.PlayStation.HighLevel.UI.Label();
			uiScore1.Text = "1st Score: 0";
			uiScore1.HorizontalAlignment = HorizontalAlignment.Center;
			uiScore1.VerticalAlignment = VerticalAlignment.Top;
			uiScore1.SetPosition(Director.Instance.GL.Context.GetViewport().Width/2 - uiScore1.Width/2, Director.Instance.GL.Context.GetViewport().Height*0.3f);		
			uiScore1.TextColor = new UIColor(1.0f, 0.756f, 0.145f, 1.0f);
			uiScore1.Font = new UIFont(FontAlias.System, 25, FontStyle.Bold);
			
			uiScore2 = new Sce.PlayStation.HighLevel.UI.Label();
			uiScore2.Text = "2nd Score: 0";;
			uiScore2.HorizontalAlignment = HorizontalAlignment.Center;
			uiScore2.VerticalAlignment = VerticalAlignment.Top;
			uiScore2.SetPosition(Director.Instance.GL.Context.GetViewport().Width/2 - uiScore1.Width/2, Director.Instance.GL.Context.GetViewport().Height*0.4f);		
			uiScore2.TextColor = new UIColor(1.0f, 0.756f, 0.145f, 1.0f);
			uiScore2.Font = new UIFont(FontAlias.System, 25, FontStyle.Bold);
			
			uiScore3 = new Sce.PlayStation.HighLevel.UI.Label();
			uiScore3.Text = "3rd Score: 0";
			uiScore3.HorizontalAlignment = HorizontalAlignment.Center;
			uiScore3.VerticalAlignment = VerticalAlignment.Top;
			uiScore3.SetPosition(Director.Instance.GL.Context.GetViewport().Width/2 - uiScore1.Width/2, Director.Instance.GL.Context.GetViewport().Height*0.5f);		
			uiScore3.TextColor = new UIColor(1.0f, 0.756f, 0.145f, 1.0f);
			uiScore3.Font = new UIFont(FontAlias.System, 25, FontStyle.Bold);
			
			uiScore4 = new Sce.PlayStation.HighLevel.UI.Label();
			uiScore4.Text = "4th Score: 0";
			uiScore4.HorizontalAlignment = HorizontalAlignment.Center;
			uiScore4.VerticalAlignment = VerticalAlignment.Top;
			uiScore4.SetPosition(Director.Instance.GL.Context.GetViewport().Width/2 - uiScore1.Width/2, Director.Instance.GL.Context.GetViewport().Height*0.6f);		
			uiScore4.TextColor = new UIColor(1.0f, 0.756f, 0.145f, 1.0f);
			uiScore4.Font = new UIFont(FontAlias.System, 25, FontStyle.Bold);
			
			
			uiScore5 = new Sce.PlayStation.HighLevel.UI.Label();
			uiScore5.Text = "5th Score: 0";
			uiScore5.HorizontalAlignment = HorizontalAlignment.Center;
			uiScore5.VerticalAlignment = VerticalAlignment.Top;
			uiScore5.SetPosition(Director.Instance.GL.Context.GetViewport().Width/2 - uiScore1.Width/2, Director.Instance.GL.Context.GetViewport().Height*0.7f);		
			uiScore5.TextColor = new UIColor(1.0f, 0.756f, 0.145f, 1.0f);
			uiScore5.Font = new UIFont(FontAlias.System, 25, FontStyle.Bold);
		}
		
	}
}

