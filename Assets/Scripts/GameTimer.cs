using UnityEngine;

namespace Sokabon
{
	public class GameTimer
	{
		private float _timer = 0;
		public bool Running => _started && _running;//even if _running is true when we are not started, this should report false.
		private bool _running = false;
		public bool Started => _started;
		private bool _started = false;
		public void StartTimer()
		{
			_started = true;
			_running = true;
			_timer = 0;
		}

		public void SetPaused(bool paused)
		{
			_running = !paused;
		}
		public void Pause()
		{
			//Pausing does not change _started.
			_running = false;
		}
		public void Unpause()
		{
			_running = true;
		}

		public void Stop()//cannot be resumed, must be restarted.
		{
			_started = false;
			_running = false;
		}
		public string GetPrettyTime()
		{
			int minutes = Mathf.FloorToInt(_timer / 60f);
			int seconds = Mathf.FloorToInt(_timer % 60f);//% is the "modulo" operator: remainder after division.

			//String formatting is fun and easy! It's not actually, but out of scope for this video.
			//A few tricks here that make this unreadable.  First, the $"words{variable}" syntax,
			//that is "string interpolation", which is a bad name but a useful feature.
			//https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated
			
			//Next is the D2 part. That is an argument that is being passed into the ToString function that the integer class has.
			//It tells the integer how to convert to a string. As a currency, a decimal, scientific notation, etc.
			
			//D means Decimal, which will just print the string as a whole number
			//2 is the minimum number of digits, adding leading 0's as needed. It will look like 00:09 and not 0:9.
			//https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings

			return $"{minutes:D2}:{seconds:D2}";
			
			//If you really want to do stuff with time, don't even bother keeping a float yourself. Hold this information as a TimeSpan object that C# has might have been easier....
		}
		
		/// <summary>
		/// Should get called in Update by the object using this timer.
		/// </summary>
		public void Tick()
		{
			//This isn't my favorite way to do GameTimers, because it requires this hook into an Update function.
			
			//I would rather just have some object that I can start, reset, pause, etc; and it just works.
			//We can do that in a variety of clever ways, like storing the start time from Time.time and calculating the difference from then to the current
			
			//But this is very simple and easy to understand

			if (_running && _started)
			{
				_timer += Time.deltaTime;
			}
		}
	}
}