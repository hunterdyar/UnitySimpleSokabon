using System;
using UnityEngine;

namespace Sokabon.StateMachine
{
	[CreateAssetMenu(fileName = "State", menuName = "StateMachine/State", order = 0)]
	public class State : ScriptableObject
	{
		public Action OnEnterEvent;
		public Action OnExitEvent;
		public bool IsCurrent => _isCurrent;
		private bool _isCurrent;
		public void OnEnter()
		{
			_isCurrent = true;
			OnEnterEvent?.Invoke();
		}

		public void OnExit()
		{
			_isCurrent = false;
			OnExitEvent?.Invoke();
		}
	}
}