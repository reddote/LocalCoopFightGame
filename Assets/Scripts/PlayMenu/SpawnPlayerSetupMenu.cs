using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

namespace PlayMenu{
    public class SpawnPlayerSetupMenu : MonoBehaviour{
        public GameObject playerSetupMenuPrefab;

        private GameObject rootMenu;
        public PlayerInput input;

        private void Awake()
        {
            rootMenu = GameObject.Find("MainLayout");
            if(rootMenu != null)
            {
                var menu = Instantiate(playerSetupMenuPrefab, rootMenu.transform);
                input.uiInputModule = menu.GetComponentInChildren<InputSystemUIInputModule>();
                menu.GetComponent<PlayerSetupController>().SetPlayerIndex(input.playerIndex);
            }
        
        }
    }
}