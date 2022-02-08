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

    private void Awake()
    {
        _goalTargets = GameObject.FindObjectsOfType<GoalTarget>();
    }

    private void OnEnable()
    {
        TurnManager.AfterTurnExecutedEvent += CheckForVictory;
        TurnManager.AfterUndoEvent += CheckForVictory;
    }

    private void OnDisable()
    {
        TurnManager.AfterTurnExecutedEvent -= CheckForVictory;
        TurnManager.AfterUndoEvent -= CheckForVictory;
    }

    private void CheckForVictory()
    {
        bool victory = _goalTargets.All(gt => gt.AtGoal);
        if (victory)
        {
            Debug.Log("We win!");
        }
    }
}
