using UnityEngine;
using TMPro;
using UnityEngine.UI;

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

        //소지금 읽기 전용 속성
        public static int Money
        {
            get { return money; }
        }

        //초기 소지금
        [SerializeField]
        private int startMoney = 400;

        //소지금 UI Text
        //public TextMeshProUGUI moneyText;

        #endregion

        #region Unity Event Method
        private void Start ()
        {
            money = startMoney;     //초기 소지금 지급
            Debug.Log($"초기 소지금 {startMoney}골드를 지급하였습니다");
        }


        #endregion

        #region Custom Method

        //돈 벌기
        public void AddMoney(int amount)
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



       


        #endregion
    }
}
