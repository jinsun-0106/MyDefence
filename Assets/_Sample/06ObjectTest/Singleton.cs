using UnityEngine;

namespace Sample
{
    //싱글톤 패턴 클래스
    public class Singleton
    {
        //클래스의 인스턴스(객체)를 정적(static) 변수 선언
        private static Singleton instance;

        //public한 속성으로 private한 instance에 전역적 접근하기
        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    //인스턴스 생성
                    instance = new Singleton();
                }

                return instance;
            }
        }

        /*//public한 메서드로 instance에 전역적 접근하기
        public static Singleton Instance()
        {
            if (instance == null)
            {
                //인스턴스 생성
                instance = new Singleton();
            }
            return instance;
        }*/

        //필드 : 인스턴스이름.number
        public int number;


        //필드 : 인스턴스 이름.a
        //public int a;

    }
}

/*
Singleton.instance (X)
Singleton.Instance (O)

사용
Singleton.Instance.a = 10;
Debug.Log(Singleton.Instance.a.ToString());

============
Singleton.Instance.number = 10;
Debug.Log(Singleton.Instance.number.ToString());



 
*/