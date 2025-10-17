using UnityEngine;
using UnityEngine.EventSystems;

namespace MyDefence
{
    /// <summary>
    /// 맵 타일을 관리하는 클래스
    /// </summary>
    public class Tile : MonoBehaviour
    {
        #region Variables

        //BuildManager(싱글톤) 객체 선언
        private BuildManager buildManager;

        //타일에 설치된 타워 오브젝트 인스턴스
        private GameObject tower;

        //타일에 설치된 타워 오브젝트 blueprint 객체 (프리팹, 가격, 설치조정 위치 ....)
        private TowerBlueprint blueprint;

        //렌더러 컴포넌트 인스턴스 변수 선언
        private Renderer renderer;

        /*//마우스가 들어가면 바뀌는 컬러
        public Color hoverColor;

        //원래 컬러
        private Color startColor;*/

        //마우스가 들어가면 바뀌는 메터리얼
        public Material hoverMaterial;

        //원래 메터리얼
        private Material startMaterial;

        //건설 비용 부족시 바뀌는 메테리얼
        public Material moneyMaterial;

        //타워 건설 효과
        public GameObject buildEffectPrefab;
                
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //참조
            renderer = GetComponent<Renderer>();
            //renderer = this.transform.GetComponent<Renderer>();
            buildManager = BuildManager.Instance;

            //시작 컬러값 초기화
            //startColor = renderer.material.color;
            startMaterial = renderer.material;
        }

        private void OnMouseDown()
        {
            //UI로 가려져 있으면 설치하지 못한다
            if(EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            //만약 타워를 선택하지 않았으면 설치하지 못한다
            if (buildManager.CannotBuild)
            {
                Debug.Log("설치할 타워가 없습니다");
                return;
            }

            //만약 타일에 타워오브젝트가 있으면 설치하지 못한다
            if (tower != null)
            {
                Debug.Log("타워를 설치하지 못합니다");
                return;
            }

            blueprint = buildManager.GetTurretToBuild();

            //Debug.Log("마우스 클릭 - 여기에 터렛 설치");
            BuildTower();
            

        }

        private void OnMouseEnter()
        {
            //UI로 가려져 있으면 변경되지 않는다
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }


            //만약 타워를 선택하지 않았으면 반응하지 않는다
            if (buildManager.CannotBuild)
            {
                return;
            }

            if(buildManager.HasBuildCost)
            {
                renderer.material = hoverMaterial;
            }
            else
            {
                renderer.material = moneyMaterial;
            }
            

        }

        private void OnMouseExit()
        {
            //Debug.Log("마우스가 나간다 - 흰색(원래 색)");
            //renderer.material.color = startColor;
            renderer.material = startMaterial;
        }


        #endregion


        #region Custom Method
        //타워 건설
        private void BuildTower()
        {
            //건설비용 체크
            if(buildManager.HasBuildCost == false)
            {
                Debug.Log("건설 비용이 부족합니다");
                return;
            }

            //건설 비용 지불
            PlayerStats.UseMoney(blueprint.cost);

            //건설
            tower = Instantiate(blueprint.prefab, this.transform.position + blueprint.offsetPos, Quaternion.identity);

            //건설 이펙트 효과 - 생성 후 2초 뒤 킬 예약
            GameObject effectGo = Instantiate(buildEffectPrefab, this.transform.position, Quaternion.identity);
            Destroy(effectGo, 2f);

            //turretToBuild = null; 한 번 건설 후 다시 건설하지 못하게 한다
            buildManager.SetTurretToBuild(null);

            //Debug.Log($"건설하고 남은 소지금: {PlayerStats.Money}");

        }

        #endregion


    }
}
