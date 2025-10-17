using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 타워 선택 UI를 관리하는 클래스
    /// </summary>
    public class BuildMenu : MonoBehaviour
    {
        #region Variables

        //BuildManager(싱글톤) 객체 선언
        private BuildManager buildManager;

        //타워 리스트
        public TowerBlueprint machineGun;
        public TowerBlueprint rocketTower;
        public TowerBlueprint laserTower;

        #endregion

        #region Unity Event Method
        private void Start()
        {
            //참조(길이 줄이기)
            buildManager = BuildManager.Instance;
        }

        #endregion

        #region Custom method

        //머신건 버튼 선택시 호출되는 함수
        public void SelectMachineGun()
        {
            Debug.Log("머신건 타워를 선택하였습니다!");
            //turretToBuild = machineGunPrefab;
            buildManager.SetTurretToBuild(machineGun);

        }

        public void SelectRocketTower()
        {
            Debug.Log("로켓 타워를 선택하였습니다!");
            buildManager.SetTurretToBuild(rocketTower);
        }

        public void SelectLaserTower()
        {
            Debug.Log("레이저 타워를 선택하였습니다!");
            buildManager.SetTurretToBuild(laserTower);
        }

        #endregion


    }
}
