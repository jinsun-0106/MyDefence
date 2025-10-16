using UnityEngine;
using TMPro;

namespace MyDefence
{
    /// <summary>
    /// 게임 중 가지고 있는 Life를 그리는 UI 클래스
    /// </summary>
    public class DrawLifeUI : MonoBehaviour
    {
        #region Variables
        //생명 UI
        public TextMeshProUGUI lifeText;

        #endregion


        #region Unity Event Method
        private void Update()
        {
            //생명 데이터 및 UI 적용
            lifeText.text = PlayerStats.Lives.ToString();

        }

        #endregion
    }
}
