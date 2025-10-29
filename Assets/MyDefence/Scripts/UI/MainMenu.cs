using UnityEngine;

namespace MyDefence
{
    public class MainMenu : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;

        [SerializeField]
        private string loadToScene = "LevelSelect";

        #endregion

        #region Custom Method
        //플레이버튼 클릭 시 호출
        public void Play()
        {
            Debug.Log("Go to LevelSelect");
            fader.FadeTo(loadToScene);
        }

        //나가기버튼 클릭 시 호출
        public void Quit()
        {
            //Cheating
            //저장된 데이터 삭제
            PlayerPrefs.DeleteAll();

            //Debug.Log("Game Quit");

            Application.Quit();                 //어플리케이션 종료 명령/ 에디터에서는 명령 무시, 실제 파일에서는 명령 실행
        }

        #endregion
    }
}
