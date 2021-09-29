using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Kieran.TrollingGame
{
    public class TrollingCounter : MonoBehaviour
    {
        [Header("People Trolled Variables")]
        // Initial people trolled.
        [SerializeField] private int initialPeopleTrolled = 0;
        // This will be the people trolled.
        public int PeopleTrolled { get; private set; }

        [Header("Text Boxes")]
        [SerializeField] private TMP_Text trolledCountTM;


        // Start is called before the first frame update
        void Start()
        {
            PeopleTrolled = initialPeopleTrolled;
        }

        // Update is called once per frame
        void Update()
        {
            trolledCountTM.text=($"People Trolled {PeopleTrolled}");
        }

        /// <summary>
        /// Increase the total people trolled by {_peopleTrolled}.
        /// </summary>
        /// <param name="_peopleTrolled">How many people were trolled.</param>
        public void IncreasePeopleTrolled(int _peopleTrolled)
        {
            PeopleTrolled += _peopleTrolled;
        }
        
        /// <summary> Increase the people trolled by 1. </summary>
        public void IncreasePeopleTrolled()
        {
            PeopleTrolled++;
        }
        
        /// <summary> Decrease the total trolled spent by {_peopleSpent}. </summary>
        /// <param name="_peopleSpent">How many people were spent.</param>
        public void DecreasePeopleTrolled(int _peopleSpent)
        {
            PeopleTrolled -= _peopleSpent;
        }
        
        /// <summary> Decrease the people trolled by 1. </summary>
        public void DecreasePeopleTrolled()
        {
            PeopleTrolled--;
        }
    }
}