using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace MyDefence
{
    /// <summary>
    /// 미사일 발사체를 관리하는 클래스, Bullet을 상속 받는다
    /// </summary>
    public class Rocket : Bullet
    {
        #region Variables

        //거리 안에 있는 적에게 주는 범위
        public float damageRange = 3.5f;

        #endregion

        #region Unity Event Method

        private void OnDrawGizmosSelected()                 //선택할 때만 기즈모 보임
        {
            
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position, damageRange);
        }

        #endregion

        #region Custom Method

        //미사일을 기준으로 반경 안에 있는 모든 enemy를 킬하는 걸로 재정의
        protected override void HitTarget()
        {
            //타격 위치에 이팩트를 생성한 후 3초 뒤에 이팩트 오브잭트 킬
            GameObject effectGo = Instantiate(impactPrefab, this.transform.position, Quaternion.identity);
            Destroy(effectGo, 3f);

            
            //damageRange 안에 있는 모든 적에게 데미지 주는 범위
            Explosion();

            //탄환 킬
            Destroy(this.gameObject);
        }

        //damageRange 안에 있는 모든 적에게 데미지 주는 범위
        private void Explosion()
        {
            //데미지 범위 안에 있는 모든 충돌체 가져오기
            Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, damageRange);

            //모든 충돌체 중에서 enemy 찾아서 데미지 주기
            foreach (Collider collider in hitColliders)
            {
                //enemy 찾기 - tag 검사
                if(collider.tag == "Enemy")
                {
                    Damage(collider.transform);
                }

            }

        }


        #endregion

    }
}
