using UnityEngine;
using UnityEngine.UI;

namespace Sample
{
    public class Skill : MonoBehaviour
    {
        #region Variables
        public Button skillButton;
        public Image buttonImage;

        //znf 타이머
        public float coolTimer = 5f;
        private float countdown = 0f;

        //스킬 버튼 사용 가능 여부
        private bool isCharge = false;

        #endregion

        #region Unity Event Method
        private void Start()
        {
            //초기화 - 시작하자마자 한 번 사용 가능하게 만듦
            isCharge = true;
        }

        private void Update()
        {
            //스킬 버튼 쿨 타이머
            if(isCharge == false)
            {
                countdown += Time.deltaTime;
                if(countdown >= coolTimer )
                {
                    //타이머 기능 - 스킬 활성화
                    isCharge = true ;
                    skillButton.interactable = true ;

                }

                //0 -> 1, countdown: 0 -> coolTimer
                //백분율 (%) : 현재값량 / 총값량
                buttonImage.fillAmount = countdown / coolTimer;
            }
        }
        #endregion


        #region Custom Method

        public void UseSkill()
        {
            if (isCharge == false)
                return;

            Debug.Log("스킬 사용!");

            //스킬 기능 초기화
            isCharge = false;
            skillButton.interactable = false;
            //타이머 초기화
            countdown = 0f;
        }


        #endregion
    }
}
