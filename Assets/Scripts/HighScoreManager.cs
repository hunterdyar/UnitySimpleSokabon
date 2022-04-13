using System;
using System.Collections;
using System.Collections.Generic;
using Sokabon;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    //Singleton Pattern.
    public static HighScoreManager Instance => _instance;
    private static HighScoreManager _instance;
    
    //Needed to get turns.
    [SerializeField] private TurnManager _turnManager;
    
    private void Awake()
    {
        //Initialize the singleton
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);//Destroy self if we are not the only HighScoreManager in existence. There must only be one.
        }
    }

    public void OnVictory(int currentLevel, GameTimer timer)
    {
        //Get the data we need in a more usable format.
        float levelCompletionTime = timer.GetTime();
        int turnsTaken = _turnManager.GetTurnCount();
        
        CheckForHighScore(currentLevel, levelCompletionTime,turnsTaken);
    }

    private void CheckForHighScore(int level, float time, int turns)
    {
        //todo: Implement this.
        //check if new time is faster than existing time for 'level'. 
        //check if new turns is lower than current turns for 'level'.
        //Set new fastest as appropriate
    }

    public float GetFastestTime(int level)
    {
        //todo: Implement this
        //get the saved highScore for the given level.
        return 0;
    }

    public int GetFewestTurns(int level)
    {
        //todo: implement this
        return 0;
    }
}
