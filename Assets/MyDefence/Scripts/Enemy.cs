using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// Enemy를 관리하는 클래스
    /// </summary>
    public class Enemy : MonoBehaviour
    {
        #region 필드 선언부
        //이동 목표 위치를 가지고 있는 오브젝트
        public Transform target;

        //이동 속도
        public float speed = 10f;

        #endregion

        #region (Unity Event Method)
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //초기화
            target = WayPoints.points[0];
        }

        // Update is called once per frame
        void Update()
        {
            //타겟을 향해 이동하라

            //방향 설정
            Vector3 dir = target.position - this.transform.position;

            //타겟 방향으로 이동
            this.transform.Translate(dir.normalized * Time.deltaTime * speed);

            //도착 판정 - 타겟과 Enemy 사이의 거리를 구한다
            float distance = Vector3.Distance(this.transform.position, target.position);

            //타겟과 Enemy 사이의 거리가 일정 거리 안에 들러오면 도착이라고 판정
            if ( distance < 0.2f)
            {
                Arrive();
                
            }

        }
        #endregion

        #region Custom Method

        //종점 도착
        private void Arrive()
        {
            //생명 사용
            PlayerStats.UseLife(1);

            //Enemy 킬
            Destroy(this.gameObject);
            
        }


        #endregion


    }
}
