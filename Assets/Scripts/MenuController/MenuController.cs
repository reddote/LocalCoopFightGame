using UnityEngine;
using UnityEngine.SceneManagement;

namespace MenuController{
    public class MenuController : MonoBehaviour{
        public void OnClickPlayMenu(){
            SceneManager.LoadScene("PlayMenu");
        }
    }
}