using System;
using System.Collections;
using System.Collections.Generic;
using Sokabon.CommandSystem;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
	private Stack<Command> _commands;
	public static Action AfterTurnExecutedEvent;
	public static Action AfterUndoEvent;
	
	public Action<int> TurnCountChanges;//For the game as currently scoped, it would be fine for this to be static. That's usually not the case, so lets make sure the example is more widely applicable.
	public int TurnCount => _commands.Count;
	private void Awake()
	{
		_commands = new Stack<Command>();
	}

	private void Start()
	{
		TurnCountChanges.Invoke(_commands.Count);//Count is 0 on level load.
	}

	public void ExecuteCommand(Command command)
	{
		command.Execute(AfterTurnExecutedEvent);
		_commands.Push(command);
		TurnCountChanges?.Invoke(_commands.Count);
	}

	public void Undo()
	{
		if (_commands.Count > 0)
		{
			Command latest = _commands.Pop();
			latest.Undo(AfterUndoEvent);
			TurnCountChanges?.Invoke(_commands.Count);
		}
	}

	public int GetTurnCount()
	{
		return _commands.Count;
	}
}
