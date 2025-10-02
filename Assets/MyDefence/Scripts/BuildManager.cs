using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 타워 건설을 관리하는 싱글톤 클래스
    /// </summary>
    public class BuildManager : MonoBehaviour
    {
        #region Singleton
        private static BuildManager instance;

        public static BuildManager Instance
        {
            get
            {
                return instance;
            }
        }

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(this.gameObject);
                return;
            }
            instance = this;

            //DontDestroyOnLoad(this.gameObject);

        }
        #endregion

        #region Variables
        //타일에 설치할 프리팹 오브젝트를 저장하는 변수
        //여러 개의 타워 프리팹 중 선택된 프리팹을 저장하는 변수
        private GameObject turretToBuild;

        public GameObject machineGunPrefab;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            turretToBuild = machineGunPrefab;
        }

        #endregion

        #region Custom Method
        public GameObject GetTurretToBuild()
        {
            return turretToBuild;
        }

        #endregion


    }
}
