using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Kieran.TrollingGame
{
    public class Board : MonoBehaviour
    {
        [Header("The Associated Board - Drag and drop")]
        [SerializeField] private GameObject boardGameObject;
        [SerializeField] private string boardName;
        [SerializeField] private TMP_Text boardNameTextMeshPro;
        [SerializeField] private TMP_Text threadLimitTextMeshPro;
        [SerializeField] private TMP_Text threadHPTextMeshPro;
        [SerializeField] private Button trollPeopleButton;
        [Header("The MAX HP and Limit(Timer) of the thread")]
        [SerializeField] private int threadLimitMax;
        [SerializeField] private int threadHPMax;
        [Header("Details for each thread")]
        [SerializeField] private int peopleTrolledPerThread;
        
        private Thread activeThread;
        public Thread ActiveThread => activeThread;

        private void Awake()
        {
            // Gets the thread attached in the children of this button.
            activeThread = GetComponentInChildren<Thread>();
            SetUpButton();
            
            // Sets the max variables of the thread.
            activeThread.SetThreadLimit(threadLimitMax);
            activeThread.SetThreadHP(threadHPMax);
        }

        private void SetUpButton()
        {
            trollPeopleButton = GetComponentInChildren<Button>();
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