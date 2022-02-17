using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sokabon;
using Sokabon.StateMachine;
using UnityEngine;

//Todo: Manage game state.
public class GameManager : MonoBehaviour
{
    [Header("State Machine Config")] [SerializeField]
    private StateMachine machine;

    [SerializeField] private State victoryState;
    [SerializeField] private State gameplayState;
    [SerializeField] private State pauseState;
    //We need to know when a turn is done
    //We need to know all of the victory conditions
    private GoalTarget[] _goalTargets;
    private GameTimer _timer;
    
    private void Awake()
    {
        _goalTargets = GameObject.FindObjectsOfType<GoalTarget>();
        _timer = new GameTimer();
    }

    void Start()
    {
        machine.Init();
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

    public void Pause()
    {
        _timer.Pause();
        machine.SetCurrentState(pauseState);
    }

    public void UnPause()
    {
        _timer.Unpause();
        machine.SetCurrentState(gameplayState);
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
            _timer.Stop();
            machine.SetCurrentState(victoryState);
        }
    }

    private void Update()
    {
        _timer.Tick();
    }
}
