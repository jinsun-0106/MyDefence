using UnityEngine;

namespace MyDefence
{
    public class Bullet : MonoBehaviour
    {
        #region Variables
        //타겟 오브젝트
        private Transform target;

        //총알 이동 속도
        public float moveSpeed = 70f;

        //타격 이팩트 프리팹 오브젝트
        public GameObject impactPrefab;

        #endregion

        #region Unity Event Method
        private void Update()
        {
            if (target == null) return;

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
        }

        #endregion

        #region Custom Method
        //매개변수로 들어온 타켓으로 저장
        public void SetTarget(Transform _target)
        {
            target = _target;

        }

        //타겟 명중
        void HitTarget()
        {
            //타격 위치에 이팩트를 생성한 후 3초 뒤에 이팩트 오브잭트 킬
            GameObject effectGo = Instantiate(impactPrefab, target.position, Quaternion.identity);
            Destroy(effectGo, 3f);


            //타겟 킬
            //Debug.Log("히트다 히트~");
            
            Destroy(target.gameObject);
            

            //탄환 킬
            Destroy(this.gameObject);
            
            
        }

        #endregion
    }
}
