using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Kieran.TrollingGame;

namespace Kieran.TrollingGame.Helpers
{
    public class Helper_AutoClicker : MonoBehaviour
    {
        // cost and level and current money
        [Header("Read Only (you)")]
        [SerializeField] private int Level = 0;
        [SerializeField] private int cost;
    
        [Header("Drag these Suckers in, Cause I ain't coding it Chief")]
        [SerializeField] private Board linkedBoard;
        [SerializeField] private TMP_Text LevelOutput;
        [SerializeField] private  TMP_Text CostOutput;
        [SerializeField] private  Button BuyHelper;
        [SerializeField] private  TrollingCounter trollingCounter;
    
    
        [Header("Balance")]
        [SerializeField] private int initialCost;
        [SerializeField] private float costIncrease;
        [SerializeField] private int maxLevel;
    
        // Start is called before the first frame update
        void Start()
        {
            cost= (Mathf.RoundToInt(initialCost * (Mathf.Pow(costIncrease, Level))));

            BuyHelper.interactable = false;

            LevelOutput.text=("Level: " + Level);
            CostOutput.text =("$$" + cost.ToString("N0"));

            StartCoroutine(FarmingClicks());
        }

        // Update is called once per frame
        void Update()
        {
            BuyHelper.interactable = (trollingCounter.PeopleTrolled >= cost);
        }
    
        public void PurchaseHelper()
        {
            if (trollingCounter.PeopleTrolled>=cost)
            {
                trollingCounter.DecreasePeopleTrolled(cost);
                Level++;
                cost= (Mathf.RoundToInt(initialCost * (Mathf.Pow(costIncrease, Level))));
                LevelOutput.text = ("Level: " + Level);
                CostOutput.text = ("$$" + cost.ToString("N0"));
            }
        }
    
    
        // coroutine if they buy the helper
        // auto clicking paster per level
        private IEnumerator FarmingClicks()
        {
            while (true)
            {
                yield return new WaitForSeconds(2.02f - Level*0.3f);
                linkedBoard.TrollThread();
            }
        }
    }
}