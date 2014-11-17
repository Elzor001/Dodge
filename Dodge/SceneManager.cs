using System;

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
		
		public enum SceneType
		{
			startScene,
			gameScene,
			endScene,
			scoreScene,
			
		}
		
		// Singleton initialization 
		private SceneManager()
		{
		}
		
//		public static void Initialise(Scene scene)
//		{
//			if(instance == null)
//				instance = new SceneManager(scene);
//		}
		
		public static SceneManager Instance
		{
			get {return instance;}
		}
		
//		public Scene startScene(Scene scene)
//		{
//			scene = new Sce.PlayStation.HighLevel.GameEngine2D.Scene();
//			scene.Camera.SetViewFromViewport();
//			
//			textureInfo = new TextureInfo("/Application/Assets/background.png");
//			background = new SpriteUV(textureInfo);
//			background.Quad.S = textureInfo.TextureSizef;
//			scene.AddChild(background);
//			
//			return scene;
//			
//		}
		
		public void startScene()
		{
			scene = new Sce.PlayStation.HighLevel.GameEngine2D.Scene();
			scene.Camera.SetViewFromViewport();
			
			textureInfo = new TextureInfo("/Application/Assets/background.png");
			background = new SpriteUV(textureInfo);
			background.Quad.S = textureInfo.TextureSizef;
			scene.AddChild(background);
			
			Director.Instance.RunWithScene(scene, true);
			
		}
		
		public Scene gameScene(Scene scene)
		{
			return scene;
		}
		

	}
}

