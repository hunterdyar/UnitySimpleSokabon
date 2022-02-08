using UnityEngine;

namespace Sokabon.CommandSystem
{
	public class PushBlock : Command
	{
		private Block _pusher;
		private Block _pushed;
		private Vector2Int _direction;

		public PushBlock(Block pusher, Block pushed, Vector2Int direction)
		{
			_pusher = pusher;
			_pushed = pushed;
			_direction = direction;
		}

		public override void Execute()
		{
			_pusher.MoveInDirection(_direction);
			_pushed.MoveInDirection(_direction);
		}

		public override void Undo()
		{
			_pusher.MoveInDirection(-_direction);
			_pushed.MoveInDirection(-_direction);
		}
	}
}