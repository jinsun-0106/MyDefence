using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyDefence
{
    public class MainMenu : MonoBehaviour
    {
        #region Variables
        [SerializeField]
        private string loadToScene = "PlayScene";

        #endregion

        #region Custom Method
        //플레이버튼 클릭 시 호출
        public void Play()
        {
            Debug.Log("Go to PlayScene");

            SceneManager.LoadScene(loadToScene);
        }

        //나가기버튼 클릭 시 호출
        public void Quit()
        {
            Debug.Log("Game Quit");

            Application.Quit();                 //어플리케이션 종료 명령/ 에디터에서는 명령 무시, 실제 파일에서는 명령 실행
        }

        #endregion
    }
}
