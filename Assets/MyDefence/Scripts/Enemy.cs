using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// Enemy를 관리하는 클래스
    /// </summary>
    public class Enemy : MonoBehaviour
    {
        #region 필드 선언부 (Variables)
        //이동 목표 위치를 가지고 있는 오브젝트
        public Transform target;

        //이동 속도
        public float speed = 10f;

        //체력
        private float health;

        [SerializeField]
        private float startHealth = 100f;        //체력 초기값

        //죽는 효과
        public GameObject dieEffectPrefab;

        //죽음 보상
        [SerializeField]
        private int rewordMoney = 50;

        #endregion


        #region Unity Event Method
        void Start()
        {
            //초기화
            health = startHealth;

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

        //매개변수로 들어온 만큼 데미지를 입는다(체력 깎임)
        public void TakeDamage(float damage)
        {
            health -= damage;
            //Debug.Log($"Enemy Health: {health}");

            //죽음 체크
            if (health <= 0)
            {
                health = 0;
                Die();
            }

        }

        //죽음 처리
        private void Die()
        {
            //죽음 처리 (사운드, 이펙트 등등 넣으면 됨)

            //죽음 이펙트 효과 - 생성 후 몇 초 뒤 킬 예약
            GameObject effectGo = Instantiate(dieEffectPrefab, this.transform.position, Quaternion.identity);
            Destroy(effectGo, 1.5f);

            //보상 처리 - 죽이면 돈 50 줌
            PlayerStats.AddMoney(rewordMoney);

            //Enemy Kill
            Destroy(this.gameObject);

        }



        #endregion


    }
}
