using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour {

	private float _timeCounter = 0.0f;
	[SerializeField]
	private Text _timeText;
	
	private int _counter = 1;
	private bool _countTime = true;
	
	public bool countTime
	{
		get
		{
			return _countTime;
		}
		set
		{
			_countTime = value;
		}
	}
	public int timeCounted
	{
		get{return _counter;}
	}
	
	// Update is called once per frame
	void Update()
	{
		if (_countTime)
		{
			if (_timeCounter >= _counter) //Updating Text each frame would be very CPU expensive
			{
				//Convert float in minute and second
				TimeSpan time = TimeSpan.FromSeconds(_counter);
				
				_timeText.text = "Time: " + new DateTime(time.Ticks).ToString("mm:ss");
				_counter++;
			}
			_timeCounter += Time.deltaTime;
		}
	}
}

