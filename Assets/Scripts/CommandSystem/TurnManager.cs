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
	private void Awake()
	{
		_commands = new Stack<Command>();
	}

	public void ExecuteCommand(Command command)
	{
		command.Execute();
		_commands.Push(command);
		AfterTurnExecutedEvent?.Invoke();
	}

	public void Undo()
	{
		if (_commands.Count > 0)
		{
			Command latest = _commands.Pop();
			latest.Undo();
			AfterUndoEvent?.Invoke();
		}
	}
	
}
