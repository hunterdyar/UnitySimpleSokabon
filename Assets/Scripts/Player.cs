using System;
using System.Threading;
using Sokabon.CommandSystem;
using Sokabon.StateMachine;
using UnityEngine;

namespace Sokabon
{
	public class Player : StateChangeListener
	{
		private Block _block;
		[SerializeField] private TurnManager _turnManager;
		private bool _canMove = true;
		private void Awake()
		{
			_canMove = true;
			_block = GetComponent<Block>();
			
			//We have a dependency on TurnManager.
			//TurnManager has not implemented the singleton pattern in this example. This is a clear weak link in this project as an example project.
			//Mostly that's because I don't want to demonstrate the singleton pattern here....
			//TurnManager doesn't need to be a monobehaviour. We, the Player, could just have one. turnManager = new TurnManager(); It could also be a ScriptableObject. ScriptableObject-Instead-of-singletons data approach is something I am partial to, but it's got all sorts of quirks, to put it nicely.
			//I like to keep my player pretty bare, and move logic away from them to managers that can just hang out. A) it makes working with AI, game-state-search (solving), or such where we may not have a proper "player" easier, and B) it makes destroying the player for animations and fade-outs and ragdolls and cutscenes and such easier.
			if (_turnManager == null)
			{
				Debug.LogWarning("Player object needs TurnManager set, or TurnManager not found in scene. Searching for one.",gameObject);
				_turnManager = GameObject.FindObjectOfType<TurnManager>();
			}
		}

		//Returns true or false if we were able to move. That way we can hook up like a "blah" feedback or noise if the player tries to move but cant.
		public bool TryMove(Vector2Int direction)
		{
			if (_block.IsDirectionFree(direction))
			{
				CommandSystem.Move move = new Move(_block,direction);
				_turnManager.ExecuteCommand(move);
				return true;
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
						return true;
					}
				}
			}

			return false;
		}

		protected override void OnEnterEvent()
		{
			_canMove = true;
		}

		protected override void OnExitEvent()
		{
			_canMove = false;
		}

		private void Update()
		{
			if (!_canMove)
			{
				return;//cant move.
			}
			
			
			//Todo: Joystick support.
			//Actual Todo: switch to new input system.
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
