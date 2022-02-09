using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class UITimerText : MonoBehaviour
{
	private TMP_Text _text;
	[SerializeField] private GameManager _gameManager;
	private void Awake()
	{
		_text = GetComponent<TMP_Text>();
	}

	private void Update()
	{
		_text.text = _gameManager.GetTimer().GetPrettyTime();
	}
}
