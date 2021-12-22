using System;
using TMPro;
using UnityEngine;

namespace PlayMenu{
    public class PlayerSetupController : MonoBehaviour{
        private int playerIndex;
        private int characterIndex;

        [SerializeField] private TextMeshProUGUI playerText;
        [SerializeField] private GameObject characterSelection;
        [SerializeField] private GameObject readyText;
        
        
        private float ignoreInputTime = 1.5f;
        private bool inputEnabled;

        public void SetPlayerIndex(int index){
            playerIndex = index;
            playerText.text = "Player " + (playerIndex + 1);
            ignoreInputTime = Time.time + ignoreInputTime;
        }
        
        private void Update(){
            if (Time.time > ignoreInputTime){
                inputEnabled = true;
            }
        }

        public void SetCharacterIndex(int index){
            characterIndex = index;
        }

        public void SelectCharacter(int charIndex){
            if (!inputEnabled){
                return;    
            }
            
            PlayerConfigurationManager.Instance.SetPlayerCharacter(playerIndex, charIndex);
            characterSelection.SetActive(false);
            readyText.SetActive(true);
            ReadyPlayer();
        }

        private void ReadyPlayer(){
            PlayerConfigurationManager.Instance.ReadyPlayer(playerIndex);
        }
    }
}