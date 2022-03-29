using System;
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

		public override void Execute(Action onComplete)
		{
			_block.MoveInDirection(_direction, false, onComplete);
		}

		public override void Undo(Action onComplete)
		{
			_block.MoveInDirection(-_direction, true, onComplete);
		}
	}
}