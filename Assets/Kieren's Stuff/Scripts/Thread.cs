using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

namespace Kieran.TrollingGame
{
    public class Thread : MonoBehaviour
    {
        [Header("The thread Limit or time before thread resets.")]
        [SerializeField] private float threadLimitMax;
        [SerializeField] private float threadLimitCurrent;
        [Header("The thread HP.")]
        [SerializeField] private int threadHPMax;
        [SerializeField] private int threadHPCurrent;
        [Header("Is this the Current Thread.")]
        [SerializeField] private bool currentThread = false;
        // Text Boxes
        private TMP_Text threadLimitText;
        private TMP_Text threadHpText;
        

        private void Start()
        {
            threadLimitText = GameObject.FindGameObjectWithTag("ThreadLimitTextBox").GetComponent<TMP_Text>();
            threadHpText = GameObject.FindGameObjectWithTag("ThreadHPTextBox").GetComponent<TMP_Text>();
            currentThread = false;
        }

        // Change if the current thread is active.
        public void ChangeIsCurrentThreadActive()
        {
            currentThread = currentThread == false;
        }

        private void Update()
        {
            if(currentThread)
            {
                threadLimitText.text = ($"Thread limit \n{(int) threadLimitCurrent}");
                threadHpText.text = ($"Thread HP \n{threadHPCurrent}");
            }
        }

        private void FixedUpdate()
        {
            threadLimitCurrent -= Time.fixedDeltaTime;

            if(threadLimitCurrent <= 0)
            {
                ResetThread();
            }
        }

        private void ResetThread()
        {
            threadHPCurrent = threadHPMax;
            threadLimitCurrent = threadLimitMax;
        }

        /// <summary>
        /// Setup the max Thread Limit of the threads.
        /// </summary>
        /// <param name="_threadLimitMax">Max Thread Limit of threads.</param>
        public void SetThreadLimit(float _threadLimitMax)
        {
            threadLimitMax = _threadLimitMax;
            threadLimitCurrent = threadLimitMax;
        }
        /// <summary>
        /// Setup the max HP of the threads.
        /// </summary>
        /// <param name="_threadHPMax">Max HP of threads.</param>
        public void SetThreadHP(int _threadHPMax)
        {
            threadHPMax = _threadHPMax;
            threadHPCurrent = threadHPMax;
        }

        public bool TrollThread(int _threadTrolledAmount)
        {
            // Troll thread by ammount.
            threadHPCurrent -= _threadTrolledAmount;

            if(threadHPCurrent <= 0)
            {
                // Thread Trolled.
                threadHPCurrent = threadHPMax;
                // If it has been trolled yet return true.
                return true;
            }
            // If it hasn't been trolled yet return false.
            return false;
        }
    }
}