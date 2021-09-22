using System;
using TMPro;
using UnityEngine;

namespace Xavier_s_Stuff.Scripts
{
    public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST}
    
    public class BattleSytem : MonoBehaviour
    {
        private GameObject enemyPrefab;

        private Transform enemeyBS;

        private Turnbased enemyUnit;

        private TextMeshProUGUI dialogueText;
        
        private BattleState state;
        private void Start()
        {
            state = BattleState.START;
            SetupBattle();
        }

        private void SetupBattle()
        {
            GameObject enemyGO = Instantiate(enemyPrefab, enemeyBS);
            enemyUnit= enemyGO.GetComponent<Turnbased>();
            Instantiate(enemyPrefab, enemeyBS);
            
            dialogueText.text = "A wild " + enemyUnit.unitName + " appears!?!";
        }
    }
}