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
        [SerializeField] private TMP_Text threadLimitTextMeshPro;
        [SerializeField] private TMP_Text threadHPTextMeshPro;
        [SerializeField] private Image threadImagePanel;
        [SerializeField] private Sprite[] imagesToUseForThread;
        private int currentImage = 0;
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
            
            // Change the thread on start up
            ChangeThread();
        }

        private void ChangeThread()
        {
            int tempX = Random.Range(0, imagesToUseForThread.Length-1);

            // If the number is top or bottom of the array or equal to the number, change it to 1 up or 1 down.
            if (tempX == currentImage)
            {
                if(tempX == imagesToUseForThread.Length-1)
                {
                    if(Random.Range(0, 1) > 0)
                    {
                        tempX = imagesToUseForThread.Length - 2;
                    }
                    else
                    {
                        tempX = 0;
                    }
                }
                else if(tempX == 0)
                {
                    if(Random.Range(0, 1) > 0)
                    {
                        tempX = 1;
                    }
                    else
                    {
                        tempX = imagesToUseForThread.Length-1;
                    }
                }
                else
                {
                    if(Random.Range(0, 1) > 0)
                    {
                        tempX++;
                    }
                    else
                    {
                        tempX--;
                    }
                }
            }
            currentImage = tempX;
            threadImagePanel.sprite = imagesToUseForThread[currentImage];
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
            ChangeThread();
        }
    }
}