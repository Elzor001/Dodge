using System;

namespace Dodge
{
	public class Spawner
	{
		private Enemy mPrototype;
		public Spawner (Enemy prototype)
		{
			mPrototype = prototype;
		}
		
		public Enemy SpawnEnemy()
		{
			return mPrototype.Clone();
		}
	}
}

