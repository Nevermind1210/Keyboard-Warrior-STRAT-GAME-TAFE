using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Kieran.TrollingGame
{
	public class Website : MonoBehaviour
	{
		// The name of the website.
		[SerializeField] private String WebsiteName;
		
		// All the boards under this website.
		[SerializeField] private List<Board> allBoardsOnWebsite;
		[SerializeField] private GameObject websiteHomePage;
		
		private TrollingManager trollingManager;
		
		private void Start()
		{
			trollingManager = FindObjectOfType<TrollingManager>();
			
			// Gets all boards in children, adds them as a list.
			Board[] allBoardsOnWebsitetemp = GetComponentsInChildren<Board>();

			// Add all the boards, make first board active and turn rest off.
			for(int i = 0; i < allBoardsOnWebsitetemp.Length; i++)
			{
				allBoardsOnWebsite.Add(allBoardsOnWebsitetemp[i]);
				allBoardsOnWebsite[i].AddWebsite(this);
				allBoardsOnWebsite[i].TurnOffThread();
			}
			
			// Turns on the Game Object That Holds the thread.
			websiteHomePage.SetActive(true);
		}

		public void MakeThreadActive(int i)
		{
			// Turns on the Game Object That Holds the thread.
			allBoardsOnWebsite[i].TurnOnThread();
			websiteHomePage.SetActive(false);
		}
		
		public void GoHome()
		{
			// Gets all boards in children, adds them as a list.
			Board[] allBoardsOnWebsitetemp = GetComponentsInChildren<Board>();
			
			// Turns off all threads.
			for(int i = 0; i < allBoardsOnWebsitetemp.Length; i++)
			{
				allBoardsOnWebsite[i].TurnOffThread();
			}

			// Turns on the Game Object That Holds the thread.
			websiteHomePage.SetActive(true);
		}

		public void ThreadCompleteAddTrolled(int _amountOfPeopleTrolled)
		{
			trollingManager.TrollPerson(_amountOfPeopleTrolled);
		}
	}
}