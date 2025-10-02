using UnityEngine;

namespace Sample
{

    public class SingletonTest : MonoBehaviour
    {
        private void Start ()
        {
            //정적 멤버 변수 사용하기(전역적 접근)
            StaticTest.number = 20;
            Debug.Log(StaticTest.number.ToString());



            //싱글톤 패던 클래스 인스턴스
            //싱글톤 클래스는 new해서 사용하지 않는다!
            /*Singleton singleton = new Singleton ();
            Debug.Log(singleton.ToString());            => 문법상 맞지만 이렇게 사용하지 않음*/

            var singletonA = Singleton.Instance;
            var singletonB = Singleton.Instance;
            if (singletonA == singletonB)
            {
                Debug.Log(singletonA.ToString());
            }

            Singleton.Instance.number = 10;
            Debug.Log(singletonA.number.ToString());

            //MonoBehaviour를 상속 받은 싱글톤 클래스
            Singleton.Instance.number = 30;
            Debug.Log(Singleton.Instance.number.ToString());


        }


    }
}

/*
디자인패턴
싱글톤(Singleton) 패턴
: 하나의 인스턴스만 존재 : new를 한 번만 한다 (한 번하고 못하게 막음)
: 클래스의 인스턴스가 전역적 접근이 가능하다: 인스턴스 변수를 static 선언

: 싱글톤의 클래스의 인스턴스 변수는 자신 클래스 코드블록 안에서 선언한다


 */