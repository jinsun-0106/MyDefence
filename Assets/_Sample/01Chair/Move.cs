using UnityEngine;

namespace Sample
{
    public class Move : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        /*void Start()
        {
            Debug.Log("앞으로 이동하기");
        }

        public float speed = 5;
        void Update ()
        {
            transform.Translate(Vector3.back*speed*Time.deltaTime);
        }*/

        public float distance = 5f; // 왕복할 거리 (총 이동 폭)
        public float speed = 2f;    // 이동 속도

        // 오브젝트의 초기 위치를 저장합니다.
        private Vector3 startPosition;

        void Start()
        {
            // 스크립트가 시작될 때 오브젝트의 현재 위치를 저장
            startPosition = transform.position;
        }

        void Update()
        {
            // 1. Mathf.PingPong 계산
            // Time.time은 게임이 시작된 이후의 시간을 나타냅니다.
            // 이 값을 speed로 곱하여 이동 속도를 조절합니다.
            // distance를 길이(length)로 사용하여 0부터 distance까지 왕복하는 값을 얻습니다.
            float offset = Mathf.PingPong(Time.time * speed, distance);

            // 2. 이동 방향 설정
            // 이 예제에서는 오브젝트의 로컬 '앞' 방향(Z축)을 사용합니다.
            Vector3 direction = transform.forward;

            // 3. 새로운 위치 계산 및 적용
            // 시작 위치에 (방향 * 왕복 오프셋)을 더하여 새로운 위치를 계산합니다.
            transform.position = startPosition + direction * offset;
        }


    }
}
