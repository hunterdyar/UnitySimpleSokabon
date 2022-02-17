using System;
using UnityEngine;

namespace Sokabon.StateMachine
{
	public class StateChangeListener : MonoBehaviour
	{
		[SerializeField] protected State state;

		protected virtual void OnEnable()
		{
			state.OnEnterEvent += OnEnterEvent;
			state.OnExitEvent += OnExitEvent;
		}

		protected virtual void OnDisable()
		{
			state.OnEnterEvent -= OnEnterEvent;
			state.OnExitEvent -= OnExitEvent;
		}

		protected virtual void OnExitEvent()
		{
			
		}

		protected virtual void OnEnterEvent()
		{
			
		}
	}
}