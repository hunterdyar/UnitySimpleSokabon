using System;
using System.Collections;
using System.Collections.Generic;
using Sokabon;
using UnityEngine;

//Also called a 'Storage Location' in Sokabon
public class Goal : MonoBehaviour
{
	[SerializeField] private LayerSettings layerSettings;

	private void Awake()
	{
		//This is some fancy bitmask work.
		//Explained here: http://answers.unity.com/comments/1263936/view.html
		if(layerSettings.goalLayerMask != (layerSettings.goalLayerMask | (1 << gameObject.layer)))
		{
			Debug.Log("Goal Object not on goal layer! You probably need to set this gameObject to the appropriate layer.",gameObject);
		}
	}
}
