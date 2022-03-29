using System;

namespace Sokabon.CommandSystem
{
	public class Command
	{
		public virtual void Execute(Action onComplete)
		{
			
		}

		public virtual void Undo(Action onComplete)
		{
			
		}
	}
}