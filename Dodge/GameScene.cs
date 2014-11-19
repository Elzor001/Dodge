using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace Dodge
{
	public class GameScene
	{
		protected static SpriteUV background;
		protected static TextureInfo textureInfo;
		protected static Sce.PlayStation.HighLevel.GameEngine2D.Scene scene;
		
		public GameScene ()
		{
		}
		public Scene getScene(){return scene;}
		
		public virtual void Update(float dT){}
		public virtual void Draw(float dT){}
	}
}

