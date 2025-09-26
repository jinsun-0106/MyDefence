using UnityEngine;

namespace Sample
{
    public class MoveTest : MonoBehaviour
    {
        //이동 목표 지점 변수 선언 및 초기화
        private Vector3 targetPosition = new Vector3(7f, 1f, 8f);

        //이동 목표 위치에 있는 오브젝트의 트랜스폼 인스턴스
        public Transform target;

        //이동 속도를 저장하는 변수를 선언하고 초기화
        public float speed;           //1초에 가는 거리

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            /*
            미세한 차이가 있음 => 경험치,,
            this.gameObject.transform
            this.transform.gameObject
            */

            //이동(transform-position)
            //this.transform.position = new Vector3(7f, 1f, 8f);
            //Debug.Log(this.transform.position);

            //this.transform.position = targetPosition;

           /* Debug.Log(target.position);
            this.transform.position = target.position;*/


            //위치 변수로 쓰기

            //회전
            //this.transform.rotation = new Quaternion(5f, 2f, 6f, 3f);
        }

        // Update is called once per frame
        void Update()
        {
            //플레이어의 위치를 앞으로 이동 : z축 값이 증가한다 (누적)
            //this.transform.position 연산으로 구현 -Vector3
            //this.transform.position.z += 1;     //에러! - 반환값을 수정할 수 없음
            //this.transform.position = this.transform.position + new Vector3(0f, 0f, 1f);          //더하기 연산으로
            //this.transform.position += new Vector3(0f, 0f, 1f);                                 //누적으로

            //앞으로 이동
            //다른 방법!(정적변수)
            //this.transform.position += Vector3.forward;


            /*            
            //앞, 뒤, 좌, 우, 위, 아래 이동 가능
            //앞
            this.transform.position += new Vector3(0f, 0f, 1f);
            this.transform.position += Vector3.forward;

            //뒤
            this.transform.position += new Vector3(0f, 0f, -1f);
            this.transform.position += Vector3.back;

            //좌
            this.transform.position += new Vector3(1f, 0f, 0f);
            this.transform.position += Vector3.left;

            //우
            this.transform.position += new Vector3(-1f, 0f, 0f);
            this.transform.position += Vector3.right;

            //위
            this.transform.position += new Vector3(0f, 1f, 0f);
            this.transform.position += Vector3.up;

            //아래
            this.transform.position += new Vector3(0f, -1f, 0f);
            this.transform.position += Vector3.down;

            Vector3(1f, 1f, 1f) Vector3.one- 단위백터
            Vector3(0f, 0f, 0f) Vector3.zero
            Vector3뒤에 두개만 쓰며 z값은 0

*/

            //앞 방향으로 1초에 1유닛 만큼씩 이동하라 (초속)
            //this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime;
            //this.transform.position += Vector3.forward * Time.deltaTime;

            //앞 방향으로 1초에 5 만큼씩 이동하라
            //this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime * 5;
            //this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime * speed;

            //Translate
            //dir(방향) : 이동할 방향
            //Time.deltaTime : 동일한 시간에 동일한 거리를 이동하게 해준다
            //속도(speed) : 이동의 빠르기 지정 
            //dir * Time.deltaTime * speed => 연산의 결과는 Vector3
            //transform.Translate(Vector3.forward * Time.deltaTime * speed);

            //이동 방향 구하기 : (목표지점 - 현재지점)/ (도착위치 - 현재위치)
            Vector3 dir = target.position - this.transform.position;        //= 방향
            //dir.normalized : 단위백터, 길이가 1인 벡터, 정규화된 백터 => 방향
            //dir.magnitude : 백터의 길이, 크기

            this.transform.Translate(dir.normalized*Time.deltaTime*speed);
            //this.transform.Translate(dir.normalized * Time.deltaTime * speed, Space.Self);      //Space.Self 생략된 것

            /*
            //Space.Self, Space.World
            //Space.Self : 로컬 축 기준
            this.transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);
            //Space.World : 글로벌 축 기준
            this.transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);
            */
        }
    }
}


/*
n프레임 : 1초당 n번 실행(호출)

Time.deltaTime: 한 프레임 돌아오는데 걸리는 시간

ex)
this.transform.position += new Vector3(0f, 0f, 1f);

성능 좋은 컴
10프레임 - 1초에 10unit 이동 (Time.deltaTime 고려하지 않았을 때)
Time.deltaTime: 0.1초
Time.deltaTime을 곱하면 한 번 돌 때마다 0.1씩 증가
-> 1초에 1unit 이동함 (Time.deltaTime 고려함)

성능 나쁜 컴
2프레임 - 1초에 2unit 이동
Time.deltaTime: 0.5초
Time.deltaTime을 곱하면 한 번 돌 때마다 0.5씩 증가
-> 1초에 1unit 이동함 (Time.deltaTime 고려함)


=> 1초에 똑같은 거리를 가게 만들어야 함
=> Time.deltaTime을 곱해야 함!

 
*/