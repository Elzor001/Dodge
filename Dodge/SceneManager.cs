using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace Dodge
{
	public class SceneManager
	{
		private static SceneManager instance = new SceneManager();
		private static GameScene currentScene;
		public Random rand = new Random();
		// Singleton initialization 
		private SceneManager()
		{
			currentScene = new StartScene();
			Director.Instance.RunWithScene(currentScene.getScene(), true);
		}
		
		public static SceneManager Instance
		{
			get {return instance;}
		}

		public void runScene(float dT)
		{
			currentScene.Update(dT);
			currentScene.Draw(dT);
		}	
		public void setStartScene()
		{
			currentScene = new StartScene();
			Director.Instance.ReplaceScene(currentScene.getScene());
		}
		
		public void setInGameScene()
		{
			currentScene = new InGameScene();
			Director.Instance.ReplaceScene(currentScene.getScene());
		}
		public void setEndScene()
		{
			currentScene = new EndGameScene();
			Director.Instance.ReplaceScene(currentScene.getScene());
		}
	

	}
}

