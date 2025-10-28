using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Globalization;

namespace MyDefence
{
    /// <summary>
    /// 타이틀 씬을 관리하는 클래스
    /// </summary>
    public class Title : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;

        [SerializeField]
        private string loadToScene = "MainMenu";

        //타이머
        private float titleTimer = 10f;
        private float countdown = 0f;

        [SerializeField]
        private float showTimer = 3f;

        //쇼타임 체크
        private bool isShow = false;

        public GameObject anyKeyUI;

        #endregion

        #region Unity Evnet Method
        private void Start()
        {
            //AnyKey텍스트 3초 후에 나오기 : 3초 지연한 후에  Show
            //[1] Invoke 지연 함수
            //Invoke("ShowAnyKey", showTimer);
            //Invoke("GotoMainMenu", titleTimer + showTimer);

            //[2] 코루틴 지연함수
            StartCoroutine(TitleProcess());




        }

        private void Update()
        {
            if (isShow == false)
                return;

            //10초가 지나면 자동으로 메임메뉴로 이동
            //Invoke("GotoMainMenu", titleTimer);
            /*countdown += Time.deltaTime;
            if (countdown > titleTimer)
            {
                //타이머 기능 
                GotoMainMenu();

                //타이머 초기화
                countdown = 0f;
                return;
            }*/

            //아무 키를 누르면 메인메뉴 씬으로 이동
            if (Input.anyKeyDown)
            {
                GotoMainMenu();

                //현재 진행 중인 코루틴 함수 모두 강제 중단
                StopAllCoroutines();

            }


            

        }

        #endregion

        #region Custom Method

        private void GotoMainMenu()
        {
            fader.FadeTo(loadToScene);
        }

        private void ShowAnyKey()
        {
            isShow = true;

            anyKeyUI.SetActive(true);
        }

        IEnumerator TitleProcess()
        {
            yield return new WaitForSeconds(showTimer);
            ShowAnyKey();

            yield return new WaitForSeconds(titleTimer);
            GotoMainMenu();
        }

        #endregion
    }
}
