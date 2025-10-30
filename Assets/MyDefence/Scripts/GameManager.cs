using UnityEditor.PackageManager;
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
        private static bool isGameOver = false;

        //레벨 클리어 체크 변수
        private static bool isLevelClear = false;

        //게임오버 UI
        public GameObject gameOverUI;

        //레벨 클리어 UI
        public GameObject levelClearUI;

        //현재 플레이씬의 레벨
        [SerializeField]
        public int nowLevel = 1;

        //치트 체크 변수
        [SerializeField]
        private bool isCheating = false;

        #endregion

        #region Property
        public static bool IsGameOver
        {
            get { return isGameOver; }
            private set { isGameOver = value; }
        }

        public static bool IsLevelClear
        {
            get { return isLevelClear; }
            set { isLevelClear = value; }
        }

        #endregion

        #region Unity Event Method
        private void Start()
        {
            //초기화
            IsGameOver = false ;
            IsLevelClear = false ;
        }

        private void Update()
        {
            if (IsGameOver)
                return;


            //게임 종료 체크
            if(PlayerStats.Lives <= 0 )
            {
                GameOver();
            }

            //레벨 클리어 체크
            if (isLevelClear)
            {
                LevelClear();
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
            IsGameOver = true;

            //효과: vfx, sfx
            //패널티 적용 등등

            //UI창 열기
            gameOverUI.SetActive(true);

        }

        //레벨 클리어 처리
        private void LevelClear()
        {
            IsGameOver = true;

            //게임 데이터 저장
            int saveLevel = PlayerPrefs.GetInt("ClearLevel", 0);
            if (saveLevel < nowLevel)
            {
                PlayerPrefs.SetInt("ClearLevel", nowLevel);
                Debug.Log($"clearLevel: {nowLevel}");
            }

            //UI창 열기
            levelClearUI.SetActive(true);
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
