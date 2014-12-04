using System;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;
namespace Dodge
{
	public class Tank : Enemy
	{
		private Random rand = new Random();
		private bool leftRight;
		private SpriteUV turret;
		private TextureInfo turretTex;
		private int minSpeed, maxSpeed;
		
		public Tank (Scene scene)
		{
			// Tank Base
			texture2D = new Texture2D("/Application/Assets/tankBase2.png", false);
			numTiles = new Vector2i(1,1); // tiles in the sprite sheet
			tiles = new Vector2i(0,0); // tile you are displaying
			textureInfo = new TextureInfo(texture2D, numTiles);
			sprite = new SpriteTile(textureInfo);

			sprite.Quad.S = new Vector2(textureInfo.TextureSizef.X, textureInfo.TextureSizef.Y);
			sprite.TileIndex2D = tiles; // sets which tile you are viewing
			sprite.CenterSprite();
			
			// tank turret
			turretTex = new TextureInfo("/Application/Assets/tankTurret2.png");
			turret = new SpriteUV(turretTex);
			turret.Quad.S = turretTex.TextureSizef;
			turret.CenterSprite(TRS.Local.Center);
			
			if(SceneManager.Instance.rand.NextDouble() > 0.5)
			{
				leftRight = true;
				sprite.Rotate((float)System.Math.PI/2);
				//turret.Rotate((float)System.Math.PI/2);
			}
			else
			{
				leftRight = false;
				sprite.Rotate(-(float)System.Math.PI/2);
				//turret.Rotate(-(float)System.Math.PI/2);
			}
			
			speed = (float)SceneManager.Instance.rand.NextDouble()* 800.0f;
			position = new Vector2(300.0f, 300.0f);
			minSpeed = 100;
			maxSpeed = 200;
			setRandom();
			

			scene.AddChild(sprite);
			scene.AddChild(turret);
		}
		public override Enemy Clone() { return new Tank(scene);}
		
		public override void Update(float dT)
		{
			if(leftRight)
			{
				if(sprite.Position.X - sprite.Quad.Bounds2().Point10.X > Director.Instance.GL.Context.GetViewport().Width)
				{
					setRandom();
				}
				else
					position.X +=speed*dT;
			}
			else
			{
				if(sprite.Position.X + sprite.Quad.Bounds2().Point10.X < 0)
				{
					setRandom();
				}
				else
					position.X -=speed*dT;
			}
			sprite.Position = position;
			turret.Position = position;
			upSpeed();
			
		}
		public override void Draw(float dT)
		{
		}
		public Vector2 getPosition()
		{
			//Bounds2 b = sprite.Quad.Bounds2();
			return sprite.Position;
		}
		public Vector2 getSize()
		{
			Vector2 size = new Vector2(sprite.Quad.Bounds2().Point11.Y, sprite.Quad.Bounds2().Point11.X);
			return size;
		}
		public void setRandom()
		{
			if(leftRight)
			{
				position = new Vector2(0, (float)SceneManager.Instance.rand.NextDouble()* Director.Instance.GL.Context.GetViewport().Height);
				if(position.Y - sprite.Quad.Bounds2().Point01.Y < 0)
					position.Y = 0;
			}
			else
			{
				position = new Vector2(Director.Instance.GL.Context.GetViewport().Width, (float)SceneManager.Instance.rand.NextDouble()* Director.Instance.GL.Context.GetViewport().Height);
				if(position.Y - sprite.Quad.Bounds2().Point01.Y < 0)
					position.Y = 0;
			}
			speed = (float)SceneManager.Instance.rand.Next(minSpeed,maxSpeed);

		}
		public void rotateTurret(Vector2 pos, float dT)
		{
			float x = pos.X - turret.Position.X;
			float y = pos.Y - turret.Position.Y;
			
			Vector2 test = new Vector2(x, y);
			test = test.Normalize();
			test.X = FMath.Sin (test.X) ;
			test.Y = -FMath.Sin(test.Y);

			turret.Rotation = new Vector2(test.Y, test.X);

		}
		public void upSpeed()
		{
			int t = ScoreManager.Instance.getTime();
			if(t < 5)
			{
				minSpeed = 100;
				maxSpeed = 200;
				return;
			}
			if(t < 10 && t >=5)
			{
				minSpeed = 200;
				maxSpeed = 400;
			}
			if(t < 20 && t >=10)
			{
				minSpeed = 400;
				maxSpeed = 600;
			}
			if(t>=20)
			{
				minSpeed = 600;
				maxSpeed = 800;
			}
		}
	}

}

