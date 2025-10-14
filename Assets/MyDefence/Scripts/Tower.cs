using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 타워를 관리하는 클래스
    /// </summary>
    public class Tower : MonoBehaviour
    {
        #region Variables
        //공격 타겟이 된 Enemy - 가장 가까운 적
        private GameObject target;

        //회전
        public Transform partToRotate;          //회전을 관리하는 오브젝트
        public float rotateSpeed = 10f;         //회전 속도

        //공격 범위
        public float attackRange = 5f;

        //찾기 타이머(변수 2개 필요!)
        public float searchTimer = 0.2f;
        private float countdown = 0f;

        //발사 타이머
        public float fireTimer = 1f;
        private float fireCountdown = 0f;

        //총알
        public GameObject bulletPrefab;
        public Transform firePoint;

        #endregion

        #region Unity Event Method

        private void Start()
        {
            //초기화(마이너스 누적은 초기화 필요)
            countdown = searchTimer;

            //countdown2 = gunTimer;
        }

        private void Update()
        {
            //타이머 공식(기능 제외)
            //0.2초마다 가장 가까운 적 찾기 (매 프레임 마다 X => 과부하 걸릴 수 있음)
            if(countdown <= 0f)
            {
                //타이머 기능 - 가까운 적 찾기
                UpdateTarget();
                

                //타이머 초기화
                countdown = searchTimer;
            }
            countdown -= Time.deltaTime;
                 

            //타겟이 null이면 밑에 실행하지 마쇼!
            if (target == null) return;



            //타겟을 향해서 partToRotate 회전
            LockOn();

            //가장 가까운 적에게 1초마다 총알을 발사
            fireCountdown += Time.deltaTime;
            if (fireCountdown >= fireTimer)
            {
                //타이머 기능
                Shoot();

                //타이머 초기화
                fireCountdown = 0f;
            }

        }


        private void OnDrawGizmosSelected()                 //선택할 때만 기즈모 보임
        {
            //타워 중심에 attackRange 범위 확인
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position, attackRange);
        }



        #endregion

        #region Custom Method
        //타워에서 가장 가까운 적 찾기
        void UpdateTarget()
        {
            //모든 오브젝트 가져오기
            //맵 위에 있는 모든 enemy 게임 오브젝트 가져오기
            //FindGameObject's'WithTag => s 꼭 있어야 함!
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            //최소거리 변수 초기화
            float minDistance = float.MaxValue;

            //최소거리에 있는 게임 오브젝트 변수
            GameObject nearEnemy = null;

            foreach (GameObject enemy in enemies)
            {
                //enemy와의 거리 구하기
                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                if(distance < minDistance)
                {
                    minDistance = distance;
                    nearEnemy = enemy;
                }
            }

            //가장 가까운 적을 찾았다! 이때 최소거리는 
            if (nearEnemy != null && minDistance <= attackRange)
            {
                target = nearEnemy;
                //Debug.Log("Shoot!!");
            }
            else
            {
                target = null;
            }

        }

        //타겟을 향해 터렛 헤드 돌리기
        void LockOn()
        {
            //방향을 구하기
            Vector3 dir = target.transform.position - this.transform.position;
            //방향의 회전값을 구하기
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Quaternion lerpRotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * rotateSpeed);
            Vector3 eulerValue = lerpRotation.eulerAngles;
            //y축 기준으로 회전
            partToRotate.rotation = Quaternion.Euler(0f, eulerValue.y, 0f);

        }

        //발사
        void Shoot()
        {
            //총알 firepoint에 생성
            GameObject bulletGo = Instantiate(bulletPrefab, firePoint.transform.position, firePoint.rotation);
            Bullet bullet = bulletGo.GetComponent<Bullet>();
            if (bullet != null )
            {
                bullet.SetTarget(target.transform);
            }

            //발사하고 맞지 않았을 때 탄환 없애기 (무효탄 제거), 보통의 슈팅 게임에서 사용됨
            //Destroy(bulletGo, 3f);
            

        }

        #endregion

    }
}
