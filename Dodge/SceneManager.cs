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
		private static SpriteUV background;
		private static TextureInfo textureInfo;
		private static Sce.PlayStation.HighLevel.GameEngine2D.Scene scene;
		private static sceneType currentScene;
		
		public enum sceneType
		{
			startScene,
			gameScene,
			endScene,
			scoreScene,
			
		}
		
		// Singleton initialization 
		private SceneManager()
		{
			currentScene = sceneType.startScene;
		}
		
		public static SceneManager Instance
		{
			get {return instance;}
		}
		
		
		public void runScene(float dT)
		{
			switch(currentScene)
			{
			case sceneType.startScene:
				initStartScene();
				while(currentScene == sceneType.startScene)
				{
					updateStart();
					drawStart();
				}
				break;
			case sceneType.gameScene:
				initGameScene();
				while(currentScene == sceneType.gameScene)
				{
					
					updateStart();
					drawStart();
				}
				break;
			case sceneType.endScene:
				break;
			}
			
			
		}
		public void setCurrentScene(sceneType scene)
		{
			currentScene = scene;
		}
		
		public void initStartScene()
		{
			currentScene = sceneType.startScene;
			scene = new Sce.PlayStation.HighLevel.GameEngine2D.Scene();
			scene.Camera.SetViewFromViewport();
			
			textureInfo = new TextureInfo("/Application/Assets/startBackground.png");
			background = new SpriteUV(textureInfo);
			background.Quad.S = textureInfo.TextureSizef;
			scene.AddChild(background);
			
			Director.Instance.RunWithScene(scene, true);
			
			
		}
		public void updateStart()
		{
			var touches = Touch.GetData (0);
			if (touches.Count > 0)
				currentScene = sceneType.gameScene;
			Director.Instance.Update();
			
		}
		public void drawStart()
		{
			Director.Instance.Render();
			Director.Instance.GL.Context.SwapBuffers();
			Director.Instance.PostSwap();
		}
		public void initGameScene()
		{
			currentScene = sceneType.gameScene;
			scene = new Sce.PlayStation.HighLevel.GameEngine2D.Scene();
			scene.Camera.SetViewFromViewport();
			
			textureInfo = new TextureInfo("/Application/Assets/gameBackground.png");
			background = new SpriteUV(textureInfo);
			background.Quad.S = textureInfo.TextureSizef;
			scene.AddChild(background);
			
			Director.Instance.ReplaceScene(scene);
		}
		

	}
}

