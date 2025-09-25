using UnityEngine;

namespace Sample
{
    //MonoBehaviour 클래스의 이벤트 함수 예제
    public class EventTest : MonoBehaviour
    {
        private void Awake()
        {
            Debug.Log("[1] Awake 실행");          //1회 실행, 초기화
        }

        private void OnEnable()
        {
            Debug.Log("[7-1] OnEnable 실행");          //1회 실행 - 활성화 할 때 마다
        }

        private void Start()
        {
            Debug.Log("[2] Start 실행");          //1회 실행, 초기화(거의 대부분 초기화)

        }

        private void FixedUpdate()
        {
            Debug.Log("[3] FixedUpdate 실행");          //1초에 50번 호출, 고정/ 물리연산 시 자주 사용
        }

        private void Update()
        {
            Debug.Log("[4] Update 실행");          //매 프레임마다 호출, 1초 60(300, 30)번 호출- 코딩을 어떻게 하느냐에 따라 다르게 호출
        }

        private void LateUpdate()
        {
            Debug.Log("[5] LateUpdate 실행");          //Update() 실행 뒤에 바로 따라서 실행/ 보통 3인칭 카메라에 자주 사용됨
        }

        private void OnDisable()
        {
            Debug.Log("[7-2] OnDisable 실행");          //1회 실행 - 비활성화 할 때 마다
        }

        private void OnDestroy()
        {
            Debug.Log("[6] OnDestory 실행");          //메모리에서 사라질 때(하이라키 창에서 삭제될 때 = 킬ㄴ) - 1회 실행
        }

    }
}
