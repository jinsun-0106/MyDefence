using UnityEngine;
using TMPro;

namespace Sample
{
    /// <summary>
    /// Old Input 테스트
    /// </summary>
    public class InputTest : MonoBehaviour
    {
        #region Variables

        float centerX;          //화면 중앙 위치 x좌표
        float centerY;          //화면 중앙 위치 y좌표

        //마우스 위치값
        public TextMeshProUGUI positionText;

        #endregion

        #region Unity Event Method
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //스크린의 크기
            Debug.Log($"Screen Width: {Screen.width}");
            Debug.Log($"Screen Heigt: {Screen.height}");

            centerX = Screen.width / 2;
            centerY = Screen.height / 2;
            Debug.Log($"Screen Center: {centerX}, {centerY}");


        }

        // Update is called once per frame
        void Update()
        {
            /*//GetKey
            if (Input.GetKey("w"))           //소문자만!
            {
                Debug.Log("w키를 누르고 있습니다");          //GetKey는 엑셀 같은 것, 계~속 행동이 이어지는 것
            }

            if (Input.GetKeyDown(KeyCode.W))         //KeyCode는 대문자! 하지만 같은 의미, 이걸 더 자주 씀
            {
                Debug.Log("w키를 눌렀습니다");         //모든 액션은 down에서 사용됨!
            }

            if (Input.GetKeyUp(KeyCode.W))
            {
                Debug.Log("w키를 눌렀다가 떼었습니다");            //Down이 있어야 Up을 쓸 수 있음
            }


            //GetButton - InputManager 정의된 Axis(버튼) 이름을 가져와서 사용
            if(Input.GetButton("Jump"))
            {
                Debug.Log("점프버튼(스페이스바)를 누르고 있습니다");
            }

            if(Input.GetButtonDown("Jump"))
            {
                Debug.Log("점프버튼(스페이스바)를 눌렀습니다");
            }

            if (Input.GetButtonUp("Jump"))
            {
                Debug.Log("점프버튼(스페이스바)를 눌렀다가 떼었습니다");
            }*/


            //GetAxes - InputManager 정의된 Axis(버튼) 이름을 가져와서 사용
            if(Input.GetButton("Horizontal"))
            {
                //a, left: -1 ~ 0
                //d, right: 0 ~ 1
                //입력이 없으면: 0
                /*float hValue = Input.GetAxis("Horizontal");
                Debug.Log($"Horizontal GetAxis: {hValue}");*/

                //a, left: -1 
                //d, right: 1
                //입력이 없으면: 0
                float hValue = Input.GetAxisRaw("Horizontal");
                Debug.Log($"Horizontal GetAxisRaw: {hValue}");

            }

            if(Input.GetButton("Vertical"))
            {
                //s, down: -1 ~ 0
                //w, up: 0 ~ 1
                //입력이 없으면: 0
                /*float vValue = Input.GetAxis("Vertical");
                Debug.Log($"Vertical GetAxis: {vValue}");*/

                //s, down: -1
                //w, up: 1
                //입력이 없으면: 0
                float vValue = Input.GetAxisRaw("Vertical");
                Debug.Log($"Vertical GetAxisRaw: {vValue}");

            }

            //키보드 처리는 위의 예제로 다 처리할 수 있음! 모바일 터치는 좀 다름,,


            //스크린 상에서 마우스 위치값 가져오기
            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;
            //Debug.Log($"Mouse Point: {mouseX}, {mouseY}");

            positionText.text = $"{mouseX}, {mouseY}";
            positionText.rectTransform.position = new Vector2(mouseX, mouseY);

        }

        #endregion
    }
}
