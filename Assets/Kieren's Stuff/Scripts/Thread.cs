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
        [Header("Text Boxes")]
        [SerializeField] private TMP_Text ThreadLimitText;
        [SerializeField] private TMP_Text ThreadHPText;

        private void Update()
        {
            ThreadLimitText.text = ($"Thread limit {threadLimitCurrent}");
            ThreadHPText.text = ($"Thread HP {threadHPCurrent}");
        }

        private void FixedUpdate()
        {
            threadLimitCurrent -= Time.fixedTime;

            if(threadLimitCurrent <= 0)
            {
                ResetThread();
            }
        }

        private void ResetThread()
        {
            threadHPCurrent = threadHPMax;
            threadLimitCurrent = threadLimitMax;
            print("Thread not trolled, new thread");
        }

        /// <summary>
        /// Setup the max Thread Limmit of the threads.
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
                print("Thread trolled, new thread");
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