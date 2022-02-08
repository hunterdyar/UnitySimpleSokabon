using System;
using UnityEngine;

namespace Sokabon
{
	public class GoalTarget : MonoBehaviour
	{
		[SerializeField] private LayerSettings _layerSettings;
		private Block _block;
		private SpriteRenderer _spriteRenderer;
		private Color _defaultColor;
		private Color _atGoalColor;
		public bool AtGoal { get; private set; }
		private void Awake()
		{
			_block = GetComponent<Block>();
			_spriteRenderer = GetComponent<SpriteRenderer>();
			_defaultColor = _spriteRenderer.color;
			_atGoalColor = Color.Lerp(_defaultColor, Color.black, 0.5f);
		}

		void Start()
		{
			CheckForGoal();
		}

		private void OnEnable()
		{
			_block.AtNewPositionEvent += CheckForGoal;
		}

		private void OnDisable()
		{
			_block.AtNewPositionEvent -= CheckForGoal;
		}

		public void CheckForGoal()
		{
			AtGoal = IsGoalHere();
			if (AtGoal)
			{
				_spriteRenderer.color = _atGoalColor;
			}
			else
			{
				_spriteRenderer.color = _defaultColor;
			}
		}

		public bool IsGoalHere()
		{
			Collider2D col = Physics2D.OverlapCircle(transform.position, 0.3f, _layerSettings.goalLayerMask);
			if (col != null && col.GetComponent<Goal>() != null)
			{
				return true;
			}

			return false;
		}
	}
}