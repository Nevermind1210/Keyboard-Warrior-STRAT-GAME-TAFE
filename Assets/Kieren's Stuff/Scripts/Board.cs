using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Kieran.TrollingGame
{
    public class Board : MonoBehaviour
    {
        [Header("If the thread is active")]
        [SerializeField] private bool isThreadActive;
        [Header("The Associated Board - Drag and drop")]
        [SerializeField] private GameObject boardGameObject;
        [SerializeField] private string boardName;
        [SerializeField] private TMP_Text boardNameTextMeshPro;
        [SerializeField] private TMP_Text threadLimitTextMeshPro;
        [SerializeField] private TMP_Text threadHPTextMeshPro;
        [Header("Manually drag and drop - Set up ->TrollThread")] // For some reason this isn't normally working.
        [SerializeField] private Button trollPeopleButton;
        [Header("The MAX HP and Limit(Timer) of the thread")]
        [SerializeField] private int threadLimitMax;
        [SerializeField] private int threadHPMax;
        [Header("Details for each thread")]
        [SerializeField] private int peopleTrolledPerClick;
        [SerializeField] private int peopleTrolledPerThread;
        
        // PRIVATE VARIABLES
        // The thread attached.
        private Thread activeThread;
        // Trust me we will need this and I spent an 8 hour night trying to do this without it once.
        private Website websiteAttached;
        
        /// <summary>
        /// Just don't worry about it
        /// </summary>
        /// <param name="_websiteAttached"></param>
        public void AddWebsite(Website _websiteAttached)
        {
            this.websiteAttached = _websiteAttached;
        }
        public Thread ActiveThread => activeThread;

        private void Awake()
        {
            // Gets the thread attached in the children of this button.
            activeThread = GetComponentInChildren<Thread>();
            // Sets the max variables of the thread.
            activeThread.SetThreadLimit(threadLimitMax);
            activeThread.SetThreadHP(threadHPMax);
            
            // Moves the thread text boxes to the thread.
            activeThread.SetUpTextBoxes(threadLimitTextMeshPro,threadHPTextMeshPro);
            // This will ensure the board name has the right name.
            boardNameTextMeshPro.text = ($"{boardName}");
        }

        public void TurnOffThread()
        {
            isThreadActive = false;
            boardGameObject.SetActive(isThreadActive);
        }
        
        public void TurnOnThread()
        {
            isThreadActive = true;
            boardGameObject.SetActive(isThreadActive);
        }

        /// <summary>
        /// Troll this thread.
        /// </summary>
        public void TrollThread()
        {
            if (activeThread.TrollThread(peopleTrolledPerClick))
            {
                ThreadComplete();
            }
        }

        private void ThreadComplete()
        {
            websiteAttached.ThreadCompleteAddTrolled(peopleTrolledPerThread);
        }
    }
}