using UnityEngine;

namespace Sample
{
    //직렬화된 구조체
    [System.Serializable]               //구조체는 이렇게 해야 인스펙터 창에 보임
    public struct TestStruct
    {
        public float value1;
        public int value2;
    }


    /// <summary>
    /// 직렬화 예제, unity에서 직렬화: 인스펙터창에서 편집 가능하게 하는 것
    /// </summary>
    public class SerialTest : MonoBehaviour
    {
        //다른 클래스에서 읽고 쓸 수 있음
        public int number = 10;

        [SerializeField]                    //SerializeField하면 private을 public처럼 인스펙터창에 편집 가능하지만 다른 클래스에서는 건들 수 없음
        private string name = "홍길동";

        //기획자가 변수를 바꿔가면서 밸런스를 조절할 때 자주 씀!

        public TestStruct testStruct;

    }
}
