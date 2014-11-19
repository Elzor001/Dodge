using System;
using System.Collections;

using System.Diagnostics;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace Dodge
{
	public class InGameScene : GameScene
	{
		private Tank tank;
		private Spawner tankSpawner;
		private ArrayList tankList;
		private Stopwatch gameTimer;
			
		public InGameScene ()
		{
			scene = new Sce.PlayStation.HighLevel.GameEngine2D.Scene();
			scene.Camera.SetViewFromViewport();
			
			textureInfo = new TextureInfo("/Application/Assets/gameBackground.png");
			background = new SpriteUV(textureInfo);
			background.Quad.S = textureInfo.TextureSizef;
			scene.AddChild(background);
			
			tank = new Tank(scene);
			tankSpawner = new Spawner(tank);
			tankList = new ArrayList();
			tankList.Add (tank);

			gameTimer = new Stopwatch();
			gameTimer.Start ();
		}
		
		public override void Update(float dT)
		{
			//tank.Update(dT);
			foreach(Enemy i in tankList)
			{
				i.Update(dT);
			}
			Director.Instance.Update();
		}
		public override void Draw(float dT)
		{
			Director.Instance.Render();
			Director.Instance.GL.Context.SwapBuffers();
			Director.Instance.PostSwap();
		}
		public void addEnemy()
		{
			tankList.Add(tankSpawner.SpawnEnemy());
		}
	}
}

