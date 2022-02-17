using Unity.Burst.Intrinsics;
using UnityEngine;

namespace Sokabon.StateMachine
{
	public class EnableChildrenWithState : StateChangeListener
	{
		void Start()
		{
			foreach (Transform child in transform)
			{
				child.gameObject.SetActive(state.IsCurrent);
			}
		}
		protected override void OnEnterEvent()
		{
			foreach (Transform child in transform)
			{
				child.gameObject.SetActive(true);
			}
			base.OnEnterEvent();
		}

		protected override void OnExitEvent()
		{
			foreach (Transform child in transform)
			{
				child.gameObject.SetActive(false);
			}
			base.OnExitEvent();
		}
	}
}