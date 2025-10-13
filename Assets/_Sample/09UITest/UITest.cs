using UnityEngine;

namespace Sample
{
    /// <summary>
    /// UI 버튼 호출 함수 구현
    /// </summary>
    public class UITest : MonoBehaviour
    {
        #region Custom Method
        //Fire 버튼 클릭시 호출되는 함수
        //Fire 버튼에 등록되는 함수
        public void Fire()
        {
            Debug.Log("발사");
        }

        //점프
        public void Jump()
        {
            Debug.Log("점프");
        }
        #endregion



    }
}
