using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyDefence
{
    /// <summary>
    /// Paused UI를 관리하는 클래스
    /// Paused UI 활성화, 비활성화, x버튼, 메인메뉴, 다시하기 버튼 기능
    /// </summary>
    public class Pause : MonoBehaviour
    {
        #region Variables

        //Paused UI 게임 오브젝트
        public GameObject paused;

        //씬 페이더
        public SceneFader fader;

        private string loadToScene = "MainMenu";

        #endregion

        #region Unity Event Method
        private void Update()
        {
            //게임오버 체크
            if (GameManager.IsGameOver)
                return;

            //ESC 키 입력시 Pause 활성화, 다시 ESC 키 입력시 비활성화
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Toggle();
            }
        }

        #endregion


        #region Custom Method

        public void Toggle()
        {
            paused.SetActive(!paused.activeSelf); // 현재 상태의 반대로

            // 창이 열렸냐?
            if (paused.activeSelf)
            {
                Time.timeScale = 0f;
                
            }
            else // 창이 닫혔냐?
            {
                Time.timeScale = 1f;                
            }
        }


        //메인메뉴 버튼을 눌렀을 때 호출
        public void MainMenu()
        {
            Debug.Log("Go to Menu");

            fader.FadeTo(loadToScene);

            // 씬을 로드하기 전에 게임 시간을 정상화
            Time.timeScale = 1f;
        }

        //게임 재시작 버튼 눌렀을 때 호출
        public void Restart()
        {
            Debug.Log("Run RESTART");


            string nowSceneName = SceneManager.GetActiveScene().name;                   //현재하고 있는 씬 이름 호출

            fader.FadeTo(nowSceneName);

            // 씬을 로드하기 전에 게임 시간을 정상화
            Time.timeScale = 1f;

        }



        #endregion
    }
}
