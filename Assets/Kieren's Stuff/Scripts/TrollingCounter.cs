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
        private int peopleTrolled;
        
        [Header("Text Boxes")]
        [SerializeField] private TMP_Text trolledCountTM;


        // Start is called before the first frame update
        void Start()
        {
            peopleTrolled = initialPeopleTrolled;
        }

        // Update is called once per frame
        void Update()
        {
            trolledCountTM.text=($"People Trolled {peopleTrolled}");
        }

        /// <summary>
        /// Update the total people trolled by {_peopleTrolled}.
        /// </summary>
        /// <param name="_peopleTrolled">How many people were trolled.</param>
        public void IncreasePeopleTrolled(int _peopleTrolled)
        {
            peopleTrolled += _peopleTrolled;
        }
        
        /// <summary>
        /// Increase the people trolled by 1.
        /// </summary>
        public void IncreasePeopleTrolled()
        {
            peopleTrolled++;
        }
    }
}