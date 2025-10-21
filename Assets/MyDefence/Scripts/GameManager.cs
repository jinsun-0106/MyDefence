using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 게임 전체를 관리하는 클래스
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        #region Variables
        //게임오버 체크 변수
        private bool isGameOver = false;

        //게임오버 UI
        public GameObject gameOverUI;

        //치트 체크 변수
        [SerializeField]
        private bool isCheating = false;

        #endregion

        #region Unity Event Method
        private void Update()
        {
            if (isGameOver)
                return;


            //게임 종료 체크
            if(PlayerStats.Lives <= 0 )
            {
                GameOver();
            }

            
            //치트키
            if (Input.GetKeyDown(KeyCode.M))
            {
                ShowMeTheMoney();
            }

            if(Input.GetKeyDown(KeyCode.O))
            {
                ShowGameOverUI();
            }

        }

        #endregion

        #region Custom Method
        //게임 오버 처리
        private void GameOver()
        {
            //Debug.Log("Game Over");
            isGameOver = true;

            //효과: vfx, sfx
            //패널티 적용 등등

            //UI창 열기
            gameOverUI.SetActive(true);


        }

        
        //치트키
        void ShowMeTheMoney()
        {
            //치트 체크
            if (isCheating == false)
                return;

            PlayerStats.AddMoney(100000);
        }

        void ShowGameOverUI()
        {
            //치트 체크
            if (isCheating == false)
                return;

            GameOver();

            }


        void LevelyupCheat()
        {
            //level++;
        }

        //...


        #endregion



    }
}
