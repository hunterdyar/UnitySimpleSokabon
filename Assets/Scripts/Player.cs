using System;
using System.Threading;
using Sokabon.CommandSystem;
using UnityEngine;

namespace Sokabon
{
	public class Player : MonoBehaviour
	{
		private Block _block;
		[SerializeField] private TurnManager _turnManager;
		private void Awake()
		{
			_block = GetComponent<Block>();
		}

		public void TryMove(Vector2Int direction)
		{
			if (_block.IsDirectionFree(direction))
			{
				CommandSystem.Move move = new Move(_block,direction);
				_turnManager.ExecuteCommand(move);
			}
			else
			{
				Block b = _block.BlockInDirection(direction);
				if (b != null)
				{
					if (b.IsDirectionFree(direction))
					{
						PushBlock pushBlockCommand = new PushBlock(_block, b, direction);
						_turnManager.ExecuteCommand(pushBlockCommand);
					}
				}
			}
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
			{
				TryMove(Vector2Int.up);
			}
			else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
			{
				TryMove(Vector2Int.down);
			}
			else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
			{
				TryMove(Vector2Int.left);
			}
			else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
			{
				TryMove(Vector2Int.right);
			}else if (Input.GetKeyDown(KeyCode.Z))
			{
				_turnManager.Undo();
			}
		}
	}
}
