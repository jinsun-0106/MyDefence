using UnityEngine;


namespace MyDefence
{
    /// <summary>
    /// 플레이어 속성, 게임 데이터 변수를 관리하는 클래스
    /// </summary>
    public class PlayerStats : MonoBehaviour
    {
        #region Variables
        //소지금
        private static int money;

        
        //초기 소지금
        [SerializeField]
        private int startMoney = 400;


        //게임 Life
        private static int lives;

        //초기 지급 생명 갯수
        [SerializeField]
        private int startLife = 10;

        #endregion

        #region Property

        //소지금 읽기 전용 속성
        public static int Money
        {
            get { return money; }
        }

        //생명 읽기 전용 속성
        public static int Lives
        {
            get { return lives; }
        }


        #endregion


        #region Unity Event Method
        private void Start ()
        {
            money = startMoney;     //초기 소지금 지급

            lives = startLife;      //초기 생명 갯수 지급

            //Debug.Log($"초기 소지금 {startMoney}골드를 지급하였습니다");

        }


        #endregion

        #region Custom Method

        //돈 벌기
        public static void AddMoney(int amount)
        {
            money += amount;
        }


        //돈을 쓰기
        public static bool UseMoney(int amount)
        {
            //소지금 체크
            if (money < amount)
            {
                Debug.Log("돈이 부족합니다");
                return false;
            }

            money -= amount;
            return true;
        }

        //소지금 체크
        public static bool HasMoney(int amount)
        {
            return money >= amount;
        }

        //Life 벌기
        public static void AddLife(int amount)
        {
            lives += amount;
        }

        //Life 쓰기
        public static void UseLife(int amount = 1)
        {
            lives -= amount;

            if(lives <= 0)
            {                
                lives = 0;
                
            }
        }

       


        #endregion
    }
}
