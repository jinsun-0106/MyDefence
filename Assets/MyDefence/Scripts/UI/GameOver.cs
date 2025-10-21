using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace MyDefence
{
    /// <summary>
    /// 게임오버 UI를 관리하는 클래스
    /// </summary>
    public class GameOver : MonoBehaviour
    {
        #region Variables
        //Rounds 텍스트
        public TextMeshProUGUI roundsText;

        #endregion
        //게임오버 UI가 활성화 될 때 Rounds 값을 한 번만 가져온다
        private void OnEnable()
        {
            //Rounds 텍스트에 PlayerStats Rounds 값 적용
            roundsText.text = PlayerStats.Rounds.ToString() + " ROUNDS SURVIVED";
        }


        #region Unity Event Method
        //매 프레임 마다 Rounds 값을 가져온다
        /*private void Update()
        {
            //Rounds 텍스트에 PlayerStats Rounds 값 적용
            roundsText.text = PlayerStats.Rounds.ToString() + " ROUNDS SURVIVED";
        }*/

        #endregion


        #region Custom Method
        //메인메뉴 버튼을 눌렀을 때 호출
        public void MainMenu()
        {
            Debug.Log("Go to Menu");
        }

        //게임 재시작 버튼 눌렀을 때 호출
        public void Restart()
        {
            Debug.Log("Run RESTART");

            //웨이브, 돈, 라이프 초기화, 타워 제거....너무 많다!

            //현재 플레이하고 있는 씬을 다시 호출
            //SceneManager.LoadScene(현재 플레이하고 있는 씬의 빌드번호);                //씬 빌드번호로 호출 (인덱스 번호)
            //SceneManager.LoadScene("현재 플레이하고 있는 씬의 이름");                  //씬 이름으로 호출

            //int nowBuildIndex = SceneManager.GetActiveScene().buildIndex;               //현재하고 있는 씬 빌드번호 호출
            string nowSceneName = SceneManager.GetActiveScene().name;                   //현재하고 있는 씬 이름 호출

            SceneManager.LoadScene(nowSceneName);



        }
       

        #endregion


    }
}
