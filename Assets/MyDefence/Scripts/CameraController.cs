using UnityEngine;
using static UnityEngine.Rendering.DebugUI;


namespace MyDefence
{
    /// <summary>
    /// 카메라 제어: 이동, 줌 인/아웃 - 올드인풋시스템
    /// </summary>
    public class CameraController : MonoBehaviour
    {
        #region Variables
        //카메라 이동 속도
        public float moveSpeed = 10f;

        //카메라 위 아래 이동 속도
        public float scrollSpeed = 10f;

        public float minPosY = 10f;         //카메라 최소 높이
        public float maxPosY = 40f;         //카메라 최대 높이

        //마우스 위치 경계 변수
        public float border = 10f;

        //카메라 이동 제어 체크 변수
        //true : 이동 불가능, false : 이동 가능
        private bool isCannotMove = false;
        #endregion

        #region Unity Event Method

        private void Update()
        {
            //esc 키를 한 번 누르면 카메라 이동을 못하게 막는다 isCannotMove = true

            //esc 키를 다시 한 번 누르면 카메라 이동을 하게 한다 isCannotMove = false
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isCannotMove == false)
                {
                    isCannotMove = true;
                }
                else if (isCannotMove == true)               //밑에 있으면 위에 return 때문에 안됨 => 위치가 중요하다!
                {
                    isCannotMove = false;
                }
            }

            //카메라 이동 제어 체크 : true이면 return 아래 코드를 실행하지 말라!
            if (isCannotMove)
                return;
            
            //w키를 입력하면 앞으로 이동
            //s키를 입력하면 뒤로 이동
            //a키를 입력하면 왼쪽으로 이동
            //d키를 입력하면 오른쪽으로 이동

            if (Input.GetButton("Horizontal"))
            {
                float hValue = Input.GetAxis("Horizontal");

                this.transform.Translate( Vector3.right * hValue * Time.deltaTime * moveSpeed, Space.World);            //hValue 곱해야 함!!

            }

            if (Input.GetButton("Vertical"))
            {
                float vValue = Input.GetAxis("Vertical");
                this.transform.Translate(Vector3.forward * vValue * Time.deltaTime * moveSpeed, Space.World);           //vValue 곱해야 함!!
            }


            //마우스를 스크린 상하좌우 끝 부분(기준 폭: 10)에 가져가면 맵을 스크롤 시킨다
            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;


            if (mouseY <= Screen.height && mouseY >= (Screen.height - border))
            {
                this.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
            }

            if(mouseY <= border && mouseY >= 0f)
            {
                this.transform.Translate(Vector3.back * Time.deltaTime * moveSpeed, Space.World);
            }

            if (mouseX <= Screen.width && mouseX >= (Screen.width - border))
            {
                this.transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.World);
            }

            if (mouseX <= border && mouseX >= 0f)
            {
                this.transform.Translate(Vector3.left * Time.deltaTime * moveSpeed, Space.World);
            }

            //마우스 스크롤값을 입력받아 줌인, 줌아웃 (높이 조절) 기능 구현
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            
            Vector3 upDownPosition = this.transform.position;
            //y축 이동만 연산 - 보정 계수 1000
            upDownPosition.y -= scroll * 1000 * Time.deltaTime * scrollSpeed;

            //카메라 최소, 최대 높이 제한
            upDownPosition.y = Mathf.Clamp(upDownPosition.y, minPosY, maxPosY);

            this.transform.position = upDownPosition;

        }

        #endregion



    }
}
