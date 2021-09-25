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
        [Header("Details for each thread")]
        [SerializeField] private int peopleTrolledPerThread;
        [Header("Button to troll(click) thread")]
        [SerializeField] private Button trollPeopleButton;
        // The thread under this board, it actually wont change but will look like it makes a new thread.
        private Thread activeThread;
        public Thread ActiveThread => activeThread;

        private void Awake()
        {
            // Gets the thread attached in the children of this button.
            activeThread = GetComponentInChildren<Thread>();
            // Sets the max variables of the thread.
            activeThread.SetThreadLimit(threadLimitMax);
            activeThread.SetThreadHP(threadHPMax);
            // Removes all funtionality of the button.
            trollPeopleButton.onClick.RemoveAllListeners();
            // Adds funtionalality to button to troll.
            trollPeopleButton.onClick.AddListener(TrollThread);
        }

        // Change the amount of people trolled per click.
        private void ChangeTrollingAmountPerClick(int _peopleTrolledPerClick)
        {
            peopleTrolledPerThread = _peopleTrolledPerClick;
        }

        public void TrollThread()
        {
            activeThread.TrollThread(peopleTrolledPerThread);
        }
    }
}