using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Sokabon
{
	[CreateAssetMenu(fileName = "MovementSettings", menuName = "Sokabon/MovementSettings", order = 0)]
	public class MovementSettings : ScriptableObject
	{
		public float timeToMove;
		public AnimationCurve movementCurve;
	}
}