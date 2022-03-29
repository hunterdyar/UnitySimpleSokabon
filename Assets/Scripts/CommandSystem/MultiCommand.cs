using System;
using System.Collections.Generic;

namespace Sokabon.CommandSystem
{
	public class MultiCommand : Command
	{
		private List<Command> _subCommands;

		public MultiCommand(List<Command> subCommands)
		{
			_subCommands = subCommands;
		}

		public override void Execute(Action onComplete)
		{
			foreach (Command c in _subCommands)
			{
				c.Execute(onComplete);
			}
		}

		public override void Undo(Action onComplete)
		{
			foreach (Command c in _subCommands)
			{
				c.Undo(onComplete);
			}
		}
	}
}