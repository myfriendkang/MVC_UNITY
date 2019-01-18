﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Beats
{
	[CreateAssetMenu (menuName="MVC/Beats/New Track", fileName ="New Beats Track.asset")]
	public class Track : ScriptableObject
	{
		[Header ("Playback settings")]
		[Tooltip ("# of beats per minute")]
		[Range(30,360)]public int bpm = 120;

		[HideInInspector]public List<int> beats;

		static public int inputs = 4;

		[Header ("Random Settings")]

		[Tooltip ("# of preroll (empty) beats")]
		[Range(0f,10f)] [SerializeField] private int _preroll = 10;
		[Tooltip ("Minimum # of beats per block")]
		[Range(1,20)] [SerializeField] private int _minBlock = 2;
		[Tooltip ("Maximum # of beats per block")]
		[Range(1,20)] [SerializeField] private int _maxBlock = 5;
		[Tooltip ("Minimum # of empty beats between blocks")]
		[Range(1,20)] [SerializeField] private int _minInterval = 1;
		[Tooltip ("Maximum # of empty beats between blocks")] 
		[Range(1,20)] [SerializeField] private int _maxInterval = 2;
		[Tooltip ("# of beats blocks")]
		[Range(1,20)] [SerializeField] private int _blocks = 10;

		public void Randomize()
		{
			beats = new List<int> ();

			for (int b = 0; b < _preroll; b++) 
			{
				beats.Add (-1);
			}

			for (int blk = 0; blk < _blocks; blk++) 
			{
				int blockLength = Random.Range (_minBlock, _maxBlock + 1);
				for (int b = 0; b < blockLength; b++) 
				{
					int beat = Random.Range (0, inputs);
					beats.Add (beat);
				}
					
				if (blk == _blocks - 1)
					break;
				
				int intervalLength = Random.Range (_minInterval, _maxInterval + 1);
				for (int b = 0; b < intervalLength; b++) 
				{
					beats.Add (-1);
				}
			}
		}

		 
	}
}
