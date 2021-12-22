using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace PlayMenu{
    public class PlayerConfigurationManager : MonoBehaviour{
        private List<PlayerConfiguration> playerConfigs;
        [SerializeField] private int MaxPlayers = 2;

        public static PlayerConfigurationManager Instance{ get; private set; }

        private void Awake(){
            if (Instance != null){
                Debug.Log("[Singleton] Trying to instantiate a seccond instance of a singleton class.");
            } else{
                Instance = this;
                DontDestroyOnLoad(Instance);
                playerConfigs = new List<PlayerConfiguration>();
            }
        }

        public void HandlePlayerJoin(PlayerInput pi){
            Debug.Log("player joined " + pi.playerIndex);
            pi.transform.SetParent(transform);

            if (!playerConfigs.Any(p => p.PlayerIndex == pi.playerIndex)){
                playerConfigs.Add(new PlayerConfiguration(pi));
            }
        }

        public List<PlayerConfiguration> GetPlayerConfigs(){
            return playerConfigs;
        }

        public void SetPlayerCharacter(int index, int characterIndex){
            playerConfigs[index].characterIndex = characterIndex;
        }

        public void ReadyPlayer(int index){
            playerConfigs[index].isReady = true;
            if (playerConfigs.Count == MaxPlayers && playerConfigs.All(p => p.isReady == true)){
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public class PlayerConfiguration{
        public PlayerConfiguration(PlayerInput pi){
            PlayerIndex = pi.playerIndex;
            Input = pi;
        }

        public PlayerInput Input{ get; private set; }
        public int PlayerIndex{ get; private set; }
        public bool isReady{ get; set; }
        public int characterIndex{ get; set; }
    }
}