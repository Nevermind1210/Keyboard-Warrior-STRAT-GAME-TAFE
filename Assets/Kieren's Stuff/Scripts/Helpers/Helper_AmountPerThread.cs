using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kieran.TrollingGame;

namespace Kieran.TrollingGame.Helpers
{
    public class Helper_AmountPerThread : HelperBased
    {
        [Header("Balance for this Helper")]
        [SerializeField] private int increaseAmmountTrolledPerLevel;
        protected override void LevelUp()
        {
            linkedBoard.IncreasePeopleTrolledPerThread(increaseAmmountTrolledPerLevel);
        } 
    }
}