using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kieran.TrollingGame;

namespace Kieran.TrollingGame.Helpers
{
    public class Helper_DamagePerClick : HelperBased
    {
        [Header("Balance for this Helper")]
        [SerializeField] private int increaseDamagePerLevel;
        protected override void LevelUp()
        {
            linkedBoard.IncreaseDamagePerClick(increaseDamagePerLevel);
        } 
    }
}