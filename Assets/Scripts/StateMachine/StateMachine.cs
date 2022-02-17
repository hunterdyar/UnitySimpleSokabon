using UnityEngine;

namespace Sokabon.StateMachine
{
	[CreateAssetMenu(fileName = "State Machine", menuName = "StateMachine/State Machine", order = 0)]
	public class StateMachine : ScriptableObject
	{
		//know about the current state
		//enter and exit states
		public State CurrentState => _currentState;
		public State _currentState;

		[SerializeField]
		private State defaultState;
		public void Init()
		{
			// _currentState = null;//dont call exit on previously used state?
			SetCurrentState(defaultState);
		}

		public void SetCurrentState(State newState)
		{
			if (_currentState != null)
			{
				_currentState.OnExit();
			}
			_currentState = newState;
			_currentState.OnEnter();
		}
	}
}