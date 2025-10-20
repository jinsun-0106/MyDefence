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

        //레이저 빔 타격 이펙트 
        public ParticleSystem laserImpact;

        //타격 라이팅
        public Light impactLight;

        // 1초 당 30데미지
        [SerializeField]
        private float laserDamage = 30f;

        //이동 속도 40% 감속
        [SerializeField]
        private float slowRate = 0.4f;

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
                //레이저를 그리지 않는다, 타격 이펙트도 정지
                if(lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    laserImpact.Stop();
                    impactLight.enabled = false;
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
            //데미지 주기
            //이동과 같은 개념 (누적해서 데미지 줌!)
            float frameDamage = Time.deltaTime * laserDamage;       //프레임 당 데미지
            Enemy enemy = target.GetComponent<Enemy>();
            if (enemy != null)
            {
                //데미지 주기
                enemy.TakeDamage(frameDamage);

                //이동속도
                enemy.Slow(slowRate);
            }


            /*damageCountdown += Time.deltaTime;
            if(damageCountdown >= damageTimer)
            {
                //타이머 기능 - 1초마다 30데미지
                Enemy enemy = target.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(laserDamage);                  //초당 데미지 주기
                }

                //타이머 초기화
                damageCountdown = 0f;
            }*/


            //라인 랜더를 그린다, 레이저 타격 효과 그리기
            if (lineRenderer.enabled == false)
            {
                lineRenderer.enabled = true;
                laserImpact.Play();
                impactLight.enabled = true;
            }

            //라인 렌더러의 시작, 끝 지점 지정
            lineRenderer.SetPosition(0, firePoint.position);            //시작점
            lineRenderer.SetPosition(1, target.transform.position);     //종점

            //레이저 타격 이펙트

            //타격 이펙트가 파이어 포인트를 바라보는 방향
            Vector3 dir = firePoint.position - laserImpact.transform.position;
            laserImpact.transform.position = target.transform.position + dir.normalized/2;          //dir.normalized/2 = 중심에서 0.5 만큼 거리를 둠(그래야 표면으로 보임/ 구의 반지름이 0.5)
            laserImpact.transform.rotation = Quaternion.LookRotation(dir);

        }


        #endregion
    }
}
