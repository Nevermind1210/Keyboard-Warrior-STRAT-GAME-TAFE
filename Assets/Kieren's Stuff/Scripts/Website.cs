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
		
		// Button to troll thread.
		[SerializeField] private Button trollThreadButton;

		private void Start()
		{
			// Get the troll thread 
			trollThreadButton = GameObject.FindGameObjectWithTag("TrollThreadButton").GetComponent<Button>();
			// Gets all boards in children, adds them as a list.
			Board[] allBoardsOnWebsitetemp = GetComponentsInChildren<Board>();

			// Add all the boards, make first board active and turn rest off.
			for(int i = 0; i < allBoardsOnWebsitetemp.Length; i++)
			{
				allBoardsOnWebsite.Add(allBoardsOnWebsitetemp[i]);
				allBoardsOnWebsite[i].gameObject.SetActive(false);
			}
			MakeThreadActive(0);
		}

		private void MakeThreadActive(int i)
		{
			// Turns on the Game Object That Holds the thread.
			allBoardsOnWebsite[i].gameObject.SetActive(true);
			// Tells the thread it is active now.
			allBoardsOnWebsite[i].ActiveThread.ChangeIsCurrentThreadActive();
			// Removes all events from the current button and adds the ability to troll people on .this current thread.
			trollThreadButton.onClick.RemoveAllListeners();
			trollThreadButton.onClick.AddListener(allBoardsOnWebsite[i].TrollThread);
		}
	}
}