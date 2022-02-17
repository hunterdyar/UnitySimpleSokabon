using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[RequireComponent(typeof(TMP_Text))]
public class UITurnsTaken : MonoBehaviour
{
	private TMP_Text _text;
	[SerializeField] private TurnManager _turnManager;
	private void Awake()
	{
		_text = GetComponent<TMP_Text>();
	}

	private void OnEnable()
	{
		_turnManager.TurnCountChanges += UpdateText;
	}

	private void OnDisable()
	{
		_turnManager.TurnCountChanges -= UpdateText;
	}

	private void UpdateText(int count)
	{
		_text.text = count.ToString("D");
	}
}
