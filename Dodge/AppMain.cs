using System;
using System.Collections.Generic;
using System.Diagnostics;

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
		static Stopwatch stopwatch = new Stopwatch();
		//private static SpriteUV background;
		//private static TextureInfo textureInfo;
		private static Enemy enemy;
		
		public static void Main (string[] args)
		{
			Director.Initialize();
			float startSeconds = 0.0f;
			float endSeconds = 0.016f;
			float lastSeconds;
			while(true)
			{
				lastSeconds = endSeconds - startSeconds;
				startSeconds = (float)stopwatch.ElapsedMilliseconds / 1000.0f;
				SystemEvents.CheckEvents();
				SceneManager.Instance.runScene(lastSeconds);
				endSeconds = (float)stopwatch.ElapsedMilliseconds / 1000.0f;
			}
			Director.Terminate();
		}

		public static void Initialize ()
		{

			Director.Initialize();

			
		}

		public static void Update ()
		{
			// Query gamepad for current state
			var gamePadData = GamePad.GetData (0);
			
			//enemy.Update();
			
			//Director.Instance.Update();
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
