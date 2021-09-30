using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Kieran.TrollingGame.Helpers
{
    /// <summary> Based on what. </summary>
    public class HelperBased : MonoBehaviour
    {
        // cost and level and current money
        [Header("Read Only (you)")]
        [SerializeField] protected int level = 0;
        [SerializeField] protected int cost;
    
        [Header("Drag these Suckers in, Cause I ain't coding it Chief")]
        [SerializeField] protected Board linkedBoard;
        [SerializeField] protected TMP_Text levelOutput;
        [SerializeField] protected TMP_Text costOutput;
        [SerializeField] protected Button buyHelper;
        [SerializeField] protected TrollingCounter trollingCounter;
    
    
        [Header("Balance")]
        [SerializeField] protected int initialCost;
        [SerializeField] protected float costIncrease;
        [SerializeField] protected int maxLevel;
    
        // Start is called before the first frame update
        void Start()
        {
            cost= (Mathf.RoundToInt(initialCost * (Mathf.Pow(costIncrease, level))));

            buyHelper.interactable = false;

            levelOutput.text=("Lvl " + level);
            costOutput.text =("$$" + cost.ToString("N0"));                      
        }

        // Update is called once per frame
        void Update()
        {
            if(level < maxLevel)
            {
                buyHelper.interactable = (trollingCounter.PeopleTrolled >= cost);
            }
        }

        /// <summary> Used to purchace a helper. </summary>
        public void PurchaseHelper()
        {
            if (trollingCounter.PeopleTrolled>=cost)
            {
                if(level <= 0)
                {
                    FirstLevelUp();
                }
                trollingCounter.DecreasePeopleTrolled(cost);
                level++;
                LevelUp();
                levelOutput.text = ("Lvl " + level);
                cost= (Mathf.RoundToInt(initialCost * (Mathf.Pow(costIncrease, level))));

                if(level < maxLevel)
                {
                    costOutput.text = ("$$" + cost.ToString("N0"));
                }
                else
                {
                    costOutput.text = ("MAX!!");
                    buyHelper.interactable = false;
                }
            }
        }

        /// <summary> Runs the every time you level up. </summary>
        protected virtual void LevelUp()
        {
            
        }
        
        /// <summary> Runs the first time you level up. </summary>
        protected virtual void FirstLevelUp()
        {
            
        }
    }
}