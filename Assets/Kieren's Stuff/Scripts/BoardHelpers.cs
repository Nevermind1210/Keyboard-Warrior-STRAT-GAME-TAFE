using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Kieran.TrollingGame
{
    public class BoardHelpers : MonoBehaviour
    {
        [Header("For when pass is bought.")]
        [SerializeField] private Button boardButton;
        [SerializeField] private GameObject shitpostingPassToBuy;
        [SerializeField] private GameObject[] helpersToBuy;
        [SerializeField] private TMP_Text shitpostCostTMP;
        [Header("Balance Numbers.")]
        [SerializeField] private int shitpostingPassCost;
        [Header("Managers --> Drag In Plz <--")] 
        [SerializeField] private TrollingCounter trollingCounter;
        [SerializeField] private GameObject trollsPanel;
        [SerializeField] private bool isThisBoardActiveOnLaunch = false;
        
        // Start is called before the first frame update
        void Start()
        {
            // Turns on the panel.
            trollsPanel.SetActive(true);
            shitpostCostTMP.text = ("$$" + shitpostingPassCost.ToString("N0"));
            // Sets the buy pass on or off.
            shitpostingPassToBuy.SetActive(!isThisBoardActiveOnLaunch);
            // Sets the buy helpers on or off.
            foreach(var powerButton in helpersToBuy)
            {
                powerButton.SetActive(isThisBoardActiveOnLaunch);
            }
            // Turns on or off the board button.
            boardButton.interactable = isThisBoardActiveOnLaunch;
            // Turns on or off the buy panel.
            trollsPanel.SetActive(isThisBoardActiveOnLaunch);
        }
        
        /// <summary> This is for when you buy a pass. </summary>
        public void ShitPostingPass()
        {
            // Basic economics, do you have enough money to buy the thing.
            if(shitpostingPassCost <= trollingCounter.PeopleTrolled)
            {
                // Here is the money.
                trollingCounter.DecreasePeopleTrolled(shitpostingPassCost);
                // Here is the thing.
                shitpostingPassToBuy.SetActive(isThisBoardActiveOnLaunch);
                // Here is the option to buy more things for the thing.
                foreach(var powerButton in helpersToBuy)
                {
                    powerButton.SetActive(isThisBoardActiveOnLaunch);
                }
                // Here is access to the thing.
                trollsPanel.SetActive(isThisBoardActiveOnLaunch);
            }
            // If you don't have enough money.
            else
            {
                // Sorry you can not have the thing.
                print("Sorry not enough people trolled");
            }
        }
    }
}