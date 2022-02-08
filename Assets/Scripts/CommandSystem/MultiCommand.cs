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

		public override void Execute()
		{
			foreach (Command c in _subCommands)
			{
				c.Execute();
			}
		}

		public override void Undo()
		{
			foreach (Command c in _subCommands)
			{
				c.Undo();
			}
		}
	}
}