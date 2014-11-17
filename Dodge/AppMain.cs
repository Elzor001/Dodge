using System;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;
using Sce.PlayStation.HighLevel.UI;

namespace Dodge
{
	public class AppMain
	{
		//private static Sce.PlayStation.HighLevel.GameEngine2D.Scene gameScene;
		
		//private static SpriteUV background;
		//private static TextureInfo textureInfo;
		private static Enemy enemy;
		
		public static void Main (string[] args)
		{
			Initialize ();

			while (true) {
				SystemEvents.CheckEvents ();
				Update ();
				Draw ();
				

			}
			Director.Terminate();
		}

		public static void Initialize ()
		{
			// Set up the graphics system

			
			Director.Initialize();
			
			//gameScene = new Sce.PlayStation.HighLevel.GameEngine2D.Scene();
			//gameScene = SceneManager.Instance.startScene(gameScene);
//			gameScene.Camera.SetViewFromViewport();
//			
//			textureInfo = new TextureInfo("/Application/Assets/background.png");
//			background = new SpriteUV(textureInfo);
//			background.Quad.S = textureInfo.TextureSizef;
//			gameScene.AddChild(background);
			
			//enemy = new Enemy(gameScene);
			SceneManager.Instance.startScene();
			
			//Director.Instance.RunWithScene(gameScene, true);
			
		}

		public static void Update ()
		{
			// Query gamepad for current state
			var gamePadData = GamePad.GetData (0);
			
			//enemy.Update();
			
			Director.Instance.Update();
		}

		public static void Draw ()
		{

			//enemy.Draw();
			Director.Instance.Render();
			Director.Instance.GL.Context.SwapBuffers();
			Director.Instance.PostSwap();
			
		}
	}
}
