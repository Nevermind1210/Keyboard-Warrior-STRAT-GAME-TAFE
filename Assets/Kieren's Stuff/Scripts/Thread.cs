using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
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
        [SerializeField] private Image threadbar;
        [Header("The thread HP.")]
        [SerializeField] private float threadHPMax;
        [SerializeField] private float threadHPCurrent;
        [SerializeField] private Image healthbar;
        // Text Boxes
        private TMP_Text threadLimitText;
        private TMP_Text threadHpText;
        
        void Start()
        {
            healthbar.fillAmount = 1;
            threadbar.fillAmount = 1;
        }
        
        public void SetUpTextBoxes(TMP_Text _threadLimitText, TMP_Text _threadHpText)
        {
            threadLimitText = _threadLimitText;
            threadHpText = _threadHpText;
        }
        
        private void Update()
        {
                threadLimitText.text = ($"Thread limit {(int) (threadLimitCurrent)}");
                threadHpText.text = ($"Thread HP {threadHPCurrent}");
                LooseTime();
        }

        private void LooseTime()
        {
            threadLimitCurrent -= Time.deltaTime*5;
            
            float fraction = threadLimitCurrent / threadLimitMax;
            threadbar.fillAmount = fraction;
            
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
            
            float fraction = threadHPCurrent / threadHPMax;
            healthbar.fillAmount = fraction;
            
            if(threadHPCurrent <= 0)
            {
                // Thread Trolled.
                ResetThread();
                // If it has been trolled yet return true.
                return true;
            }
            // If it hasn't been trolled yet return false.
            return false;
        }
    }
}