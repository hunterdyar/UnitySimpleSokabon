using UnityEngine;

namespace Sokabon.CommandSystem
{
	public class Move : Command
	{
		private Block _block;
		private Vector2Int _direction;

		public Move(Block block, Vector2Int direction)
		{
			_block = block;
			_direction = direction;
		}

		public override void Execute()
		{
			_block.MoveInDirection(_direction);
		}

		public override void Undo()
		{
			_block.MoveInDirection(-_direction);
		}
	}
}