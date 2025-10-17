using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace MyDefence
{
    /// <summary>
    /// 레이저를 쏘는 타워를 관리하는 클래스, Tower 상속 받음
    /// </summary>
    public class LaserTower : Tower
    {
        #region Variables
        //레이저 빔
        private LineRenderer lineRenderer;

        #endregion

        #region Unity Event Method
        protected override void Start()
        {
            //부모 클래스(Tower) Start() 실행
            base.Start();

            //참조
            lineRenderer = this.transform.GetComponent<LineRenderer>();
        }

        protected override void Update()
        {
            //타이머 공식(기능 제외)
            //0.2초마다 가장 가까운 적 찾기 (매 프레임 마다 X => 과부하 걸릴 수 있음)
            if (countdown <= 0f)
            {
                //타이머 기능 - 가까운 적 찾기
                UpdateTarget();


                //타이머 초기화
                countdown = searchTimer;
            }
            countdown -= Time.deltaTime;


            //타겟이 null이면(타겟 못 찾았으면) 밑에 실행하지 마쇼!
            if (target == null)
            {
                //레이저를 그리지 않는다
                if(lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                }

                return;
            }



            //타겟을 향해서 partToRotate 회전
            LockOn();

            //레이저 빔 쏘기
            ShootLaser();

        }

        #endregion

        #region Custom Method
        //레이저 빔 쏘기
        private void ShootLaser()
        {
            //라인 랜더를 그린다
            if(lineRenderer.enabled == false)
            {
                lineRenderer.enabled = true;
            }

            //라인 렌더러의 시작, 끝 지점 지정
            lineRenderer.SetPosition(0, firePoint.position);            //시작점
            lineRenderer.SetPosition(1, target.transform.position);     //종점

        }


        #endregion
    }
}
