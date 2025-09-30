using UnityEngine;

namespace Sample
{
    public class RotateTest : MonoBehaviour
    {
        #region Variables
        //축 회전 누적 값을 저장하는 변수
        //float x = 0f;

        //회전 속도
        public float rotateSpeed = 10f;

        //이동 속도
        public float moveSpeed = 5f;

        //타겟
        public Transform target;

        #endregion


        #region Unity Event Method

        void Start ()
        {
            //회전값 설정 (직접)
            //this.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            //this.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
            //this.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }

        void Update ()
        {
            //x, y, z축으로 회전 구현
            //x += 1;
            //this.transform.rotation = Quaternion.Euler(x, 0f, 0f);        //x축
            //this.transform.rotation = Quaternion.Euler(0f, x, 0f);        //y축
            //this.transform.rotation = Quaternion.Euler(0f, 0f, x);        //z축

            //[1] Rotate (자전)
            //this.transform.Rotate(Vector3.right * Time.deltaTime * rotateSpeed);        //x축 기준으로 회전
            //this.transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);           //y축 기준으로 회전
            //this.transform.Rotate(Vector3.forward * Time.deltaTime * rotateSpeed);      //z축 기준으로 회전

            //[1-2] RotateAround : 타겟을 기준으로 주위를 빙글빙글 회전 (타켓 기준으로 공전)
            //this.transform.RotateAround(target.position, Vector3.up, Time.deltaTime*20f);       //y축 기준

            /* //타겟을 향해 회전
             //1) 타겟을 향한 방향을 구한다 : 타겟위치 - 현재위치
             Vector3 dir = target.position - this.transform.position;
             //2) 타겟 방향에 대한 회전값을 구한다
             Quaternion lookRotation = Quaternion.LookRotation(dir);
             Quaternion lerpRotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * rotateSpeed);

             //회전값(xyzw)에서 euler 값(xyz) 얻어오기 (제껴지는 거 조장하기 위해-> y축만 필요)
             Vector3 eulerValue = lerpRotation.eulerAngles;
             //euler 값(xyz)에서 회전값(xyzw) 얻어오기 - y축 값만 회전
             this.transform.rotation = Quaternion.Euler(0f, eulerValue.y, 0f);*/

            //타겟을 향해 회전과 이동
            //this.transform.Translate(dir.normalized * Time.deltaTime * moveSpeed);
            Vector3 dir = target.position - this.transform.position;
            this.transform.rotation = Quaternion.LookRotation(dir);


            this.transform.position = Vector3.Lerp(this.transform.position, target.position, Time.deltaTime * moveSpeed);


        }

        #endregion


    }
}
