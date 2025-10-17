using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 탄환 발사체를 관리하는 클래스
    /// </summary>
    public class Bullet : MonoBehaviour
    {
        #region Variables
        //타겟 오브젝트
        private Transform target;

        //총알 이동 속도
        public float moveSpeed = 70f;

        //타격 이팩트 프리팹 오브젝트
        public GameObject impactPrefab;

        //공격 데미지(공격력)
        [SerializeField]
        private float attackDamage = 50f;


        #endregion

        #region Unity Event Method
        private void Update()
        {
            if (target == null)
            {
                Destroy(gameObject);
                return;
            }

            //타겟까지 이동하기
            Vector3 dir = target.position - transform.position;

            //남은 거리( == dir.magnitude )
            float distance = Vector3.Distance(target.position, transform.position);

            //이번 프레임에 이동한 거리
            float distanceThisFrame = Time.deltaTime * moveSpeed;

            if (dir.magnitude <= distanceThisFrame)
            {
                HitTarget();

                return;
            }

            transform.Translate(dir.normalized * Time.deltaTime * moveSpeed, Space.World);

            //타겟 방향으로 바라보기
            transform.LookAt(target);

        }

        #endregion

        #region Custom Method
        //매개변수로 들어온 타켓으로 저장
        public void SetTarget(Transform _target)
        {
            target = _target;

        }

        //타겟 명중
        protected virtual void HitTarget()
        {
            //타격 위치에 이팩트를 생성한 후 3초 뒤에 이팩트 오브잭트 킬
            GameObject effectGo = Instantiate(impactPrefab, this.transform.position, Quaternion.identity);
            Destroy(effectGo, 3f);

            //Debug.Log("히트다 히트~");
            //타격 당한 적에게 데미지 주기
            Damage(target);

            //탄환 킬
            Destroy(this.gameObject);
            
            
        }

        //타격 당한 적에게 데미지 주기
        protected void Damage(Transform _target)
        {
            //_target에게 attackDamage 만큼 데미지 주기
            //객체 가져오기 -> 함수 사용
            Enemy enemy =_target.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(attackDamage);

            }
                        
            //타겟 킬                        
            //Destroy(_target.gameObject);
        }

        #endregion
    }
}
