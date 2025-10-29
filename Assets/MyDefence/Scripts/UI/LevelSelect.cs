using UnityEngine;
using UnityEngine.UI;

namespace MyDefence
{
    public class LevelSelect : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        private string loadToScene = "MainMenu";

        //레벨 버튼의 부모 오브젝트
        public Transform contents;

        //레벨 버튼
        private Button[] levelButtons;

        //현재까지 클리어한 레벨
        private int clearLevel = 0;

        //자동 스크롤
        public RectTransform viewportRect;
        public RectTransform contentsRect;

        public Scrollbar scrollbar;

        #endregion

        #region Unity Event Method
        private void Start()
        {
            //저장된 데이터 가져오기
            clearLevel = PlayerPrefs.GetInt("ClearLevel", 0);

            //치트
            //clearLevel = 14;
            //Debug.Log($"clearLevel: {clearLevel}");

            //클리어 레벨: 0: 1레벨까지 오픈, 1: 2레벨까지 오픈, ...
            //clearLevel = 0;

            //레벨 버튼 배열 생성, 버튼의 갯수는 contents 자식 오브젝트 갯수
            levelButtons = new Button[contents.childCount];


            //레벨 버튼 세팅 - 락/언락
            for (int i = 0; i < levelButtons.Length; i++)
            {
                //contents 자식 오브젝트를 순서대로 가져온다
                Transform child = contents.GetChild(i);

                levelButtons[i] = child.GetComponent<Button>();

                if( i > clearLevel)
                {
                    levelButtons[i].interactable = false;
                }
            }

            //클리어 레벨에 의한 자동 스크롤 세팅
            //컨텐트 길이
            float contentsRectHeight = (1 + (int)(levelButtons.Length / 5)) * (110 + 7);
            //실제 스크롤랼
            float scrollHeight = contentsRectHeight - viewportRect.rect.height;            

            if(scrollHeight > 0)
            {
                //자동 스크롤량: 0~4: 0 , 5~9: 110+7, 10~14: (110+7) * 2, ...
                float clearLevelHeight = (int)(clearLevel / 5) * (110 + 7);                

                scrollbar.value = 1-clearLevelHeight / scrollHeight;
                if(scrollbar.value <= 0)
                {
                    scrollbar.value = 0;
                }
            }




        }


        #endregion

        #region Custom Method
        //레벨 셀렉 버튼 클릭 시 호출
        public void LevelSelectButton(string sceneName)
        {
            fader.FadeTo(sceneName);
        }

        //BackButton
        public void BackButton()
        {
            fader.FadeTo(loadToScene);
        }

        #endregion
    }
}


/*
게임 유저 데이터 : 유저가 게임 플레이하며 생산한 데이터
 : 게임 종료시에도 유지되어야 하는 데이터
세이브 / 로드 (Save / Load) : 서버 저장, 파일 시스템, PlayerPrefs (간단한 데이터를 저장하고 ~하는 시스템 제공)

저장할 데이터
: 게임 머니, 클리어 레벨

세이브 / 로드 정책
1. 세이브 시점
: 레벨 클리어 시 저장

2. 로드 시점
 : 레벨 셀렉트 씬 시작할 때

3. 게임 로드 시 체크사항
 : 저장 파일 유무 체크
파일이 없으면 - 유저 데이터를 설정 값으로 초기화, 저장하여 세이브 파일을 만든다
파일이 있으면 - 유저 데이터를 파일에 읽어들인 저장한 데이터로 초기화

4. 게임 세이브 시 체크사항
 - 레벨 클리어 데이터는 저장된 데이터와 저장할 데이터를 비교한 후 저장한다


PlayerPrefs : 세이브 / 로드
PlayerPrefs.SetInt(KeyName, Value);             //KeyName 이름으로 Value 저장
PlayerPrefs.GetInt(KeyName);                    //KeyName 이름으로 저장된 Value 가져오기

PlayerPrefs.SetFloat(KeyName, Value);             //KeyName 이름으로 Value 저장
PlayerPrefs.GetFloat(KeyName);                    //KeyName 이름으로 저장된 Value 가져오기

PlayerPrefs.SetSting(KeyName, Value);             //KeyName 이름으로 Value 저장
PlayerPrefs.GetSting(KeyName);                    //KeyName 이름으로 저장된 Value 가져오기

DeleteAll();                //저장된 모든 값 삭제
 
 */