using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Kieran.TrollingGame
{
    public class Board : MonoBehaviour
    {
        [SerializeField] private string boardName;
        [Header("The MAX HP and Limit(Timer) of the thread")]
        [SerializeField] private int threadLimitMax;
        [SerializeField] private int threadHPMax;
        [Header("Details for each click")]
        [SerializeField] private int peopleTrolledPerClick;
        [Header("Details for simps gained on each thread death")]
        [SerializeField] private int simpsGainedOnDeath;
        [Header("Button to troll(click) thread")]
        [SerializeField] private Button trollPeopleButton;
        [Header("The thread under this board")]
        // The thread under this board, it actually wont change but will look like it makes a new thread.
        [SerializeField] private Thread activeThread;
        
        private void Start()
        {
            // Sets the max variables of the thread.
            activeThread.SetThreadLimit(threadLimitMax);
            activeThread.SetThreadHP(threadHPMax);
            // Removes all funtionality of the button.
            trollPeopleButton.onClick.RemoveAllListeners();
            // Adds funtionalality to button to troll.
            trollPeopleButton.onClick.AddListener(TrollThread);
            // Gets the thread attached in the children of this button.
            activeThread = GetComponentInChildren<Thread>();
        }

        // Change the amount of people trolled per click.
        private void ChangeTrollingAmountPerClick(int _peopleTrolledPerClick)
        {
            peopleTrolledPerClick = _peopleTrolledPerClick;
        }

        public void TrollThread()
        {
            activeThread.TrollThread(peopleTrolledPerClick);
        }
    }
}