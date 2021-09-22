using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kieran.TrollingGame
{
    public class TrollingManager : MonoBehaviour
    {
        private TrollingCounter trollingCounter;
        // Start is called before the first frame update
        void Start()
        {
            trollingCounter = FindObjectOfType<TrollingCounter>();
        }

        public void TrollPerson(int _int)
        {
            trollingCounter.IncreasePeopleTrolled(_int);
        }
    }
}