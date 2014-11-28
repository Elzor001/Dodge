using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Dodge
{
	public class ScoreManager
	{
		private static ScoreManager instance = new ScoreManager();
		private static Stopwatch stopwatch = new Stopwatch();
		private static int score, lastTime;
		private static List<int> scores;
		
		private ScoreManager ()
		{
			score = 0;
			lastTime = 0;
			scores = new List<int>();
		}
		
		public static ScoreManager Instance
		{
			get {return instance;}
		}
		public void startTime()
		{
			stopwatch.Start();
		}
		public void stopTime()
		{
			stopwatch.Stop();
		}
		public void runScore()
		{
			if((int)(stopwatch.ElapsedMilliseconds / 1000.0f) - lastTime >= 1)
			{
				score++;
				lastTime = (int)(stopwatch.ElapsedMilliseconds / 1000.0f);
			}
	
		}
		public int getScore()
		{
			return score;
		}
		public int getTime()
		{
			return (int)(stopwatch.ElapsedMilliseconds / 1000.0f);
		}
		public void reset()
		{
			stopwatch.Stop();
			stopwatch.Reset();
			score = 0;
			lastTime = 0;
		}
		public void setScore()
		{
			scores.Add(score);
		}
	}
}

