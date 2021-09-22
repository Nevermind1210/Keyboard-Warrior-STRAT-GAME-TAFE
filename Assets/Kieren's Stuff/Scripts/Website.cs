using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
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

		private void Start()
		{
			// Gets all boards in children, adds them as a list.
			Board[] allBoardsOnWebsitetemp = GetComponentsInChildren<Board>();

			for(int i = 0; i < allBoardsOnWebsitetemp.Length; i++)
			{
				allBoardsOnWebsite.Add(allBoardsOnWebsitetemp[i]);
			}
			
			// Make first board active and turn rest off.
		}
	}
}