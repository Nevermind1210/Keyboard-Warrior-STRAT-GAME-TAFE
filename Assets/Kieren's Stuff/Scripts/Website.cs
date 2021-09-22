using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Website : MonoBehaviour
{
	[SerializeField]
		private class Board
		{
			[SerializeField] private int threadHP;
			[SerializeField] private int peopleTrolledPerClick;
			[SerializeField] private int simpsGainedOnDeath;
			[SerializeField] private Button trollPeople;
			[SerializeField] private Thread activeThread;


			public void CreateANewThread()
			{
			}

		[SerializeField]
		private class Thread
		{
			
		}
	}
	
	// The name of the website.
	[SerializeField] private String WebsiteName;
	// The count of the HPofTheThreads
	[SerializeField] private int ThreadHP;
}
