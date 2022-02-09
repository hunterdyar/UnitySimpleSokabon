using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sokabon;
using UnityEngine;

//Todo: Manage game state.
public class GameManager : MonoBehaviour
{
    //We need to know when a turn is done
    //We need to know all of the victory conditions
    private GoalTarget[] _goalTargets;
    private GameTimer _timer;
    private void Awake()
    {
        _goalTargets = GameObject.FindObjectsOfType<GoalTarget>();
        _timer = new GameTimer();
    }

    private void OnEnable()
    {
        TurnManager.AfterTurnExecutedEvent += AfterTurnExecutedOrUndo;
        TurnManager.AfterUndoEvent += AfterTurnExecutedOrUndo;
    }

    private void OnDisable()
    {
        TurnManager.AfterTurnExecutedEvent -= AfterTurnExecutedOrUndo;
        TurnManager.AfterUndoEvent -= AfterTurnExecutedOrUndo;
    }

    public GameTimer GetTimer()
    {
        return _timer;
    }

    private void AfterTurnExecutedOrUndo()
    {
        if (!_timer.Started)
        {
            _timer.StartTimer();
        }
        
        CheckForVictory();
    }

    private void CheckForVictory()
    {
        bool victory = _goalTargets.All(gt => gt.AtGoal);
        if (victory)
        {
            Debug.Log("We win!");
        }
    }

    private void Update()
    {
        _timer.Tick();
        
    }
}
