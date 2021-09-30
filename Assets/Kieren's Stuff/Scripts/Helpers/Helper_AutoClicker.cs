using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Kieran.TrollingGame;

namespace Kieran.TrollingGame.Helpers
{
    public class Helper_AutoClicker : HelperBased
    {
        [Header("Balance for this Helper")]
        [SerializeField] private float baseClickingInerval = 2.02f;
        [SerializeField] private float decreaseClickingInervalPerLevel = 0.19f;
        
        // coroutine if they buy the helper
        // auto clicking paster per level
        private IEnumerator FarmingClicks()
        {
            while (true)
            {
                yield return new WaitForSeconds(baseClickingInerval - level*decreaseClickingInervalPerLevel);
                linkedBoard.TrollThread();
            }
            // ReSharper disable once IteratorNeverReturns
        }
        
        protected override void FirstLevelUp()
        {
            StartCoroutine(FarmingClicks());
        } 
    }
}