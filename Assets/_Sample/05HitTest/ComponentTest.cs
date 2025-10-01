using UnityEngine;

namespace Sample
{
    //타겟위치로 이동 구현 클래스
    public class ComponentTest : MonoBehaviour
    {
        #region Variablse
        private float moveSpeed = 5f;
        private Vector3 targetPosotion;

        //[2] 타겟 오브젝트
        public Transform targetTransform;
        public GameObject targetGameObject;

        public TargetTest cTest;

        #endregion

        #region Unity Event Method
        void Start ()
        {
            //[1] 플레이어 오브젝트
            /*//ComponentTest 스크립트가 붙어있는 게임오브젝트의 객체(인스턴스) 가져오기
            //ComponentTest 스크립트가 붙어있는 게임오브젝트의 다른 컴포넌트에 접근하기
            this.transform
            //this.transform.GetComponent<컴포넌트 타입>()
            this.gameObject*/
            //this.gameObject.GetComponent<컴포넌트 타입>()
            //this.GetComponent<컴포넌트 타입>()



            //[2]
            //이동 목표 지점
            // = targetPosotion = targetGameObject.transform.position;
            //targetPosotion = targetTransform.position;

            //TargetTest 클래스의 인스턴스 생성 - 문법
            //MonoBehaviour를 상속받는 클래스는 new 인스턴스를 생성해서 사용하지 않는다!
            /*TargetTest tTest = new TargetTest();
            tTest.a = 50;*/

            //TargetTest 클래스가 붙어있는 게임오브젝트(트랜스폼) 객체를 가져와서 인스턴스에 접근한다
            //GetComponent<>()로 접근
            /*TargetTest gTest = targetGameObject.GetComponent<TargetTest>();
            gTest.a = 50;
            Debug.Log(gTest.GetB());

            TargetTest tTest = targetTransform.GetComponent<TargetTest>();
            tTest.a = 70;
            Debug.Log(tTest.GetB());*/

            //TargetTest 클래스가 붙어있는 게임오브젝트에서 직접 TargetTest 클래스 인스턴스 접근한다
            cTest.a = 90;
            Debug.Log(cTest.GetB());
            //cTest.transform.GetComponent<>();


        }

        #endregion


    }
}

/*
게임 오브젝트(트렌스폼)의 인스턴스를 가져오는 방법

[1] transform이 있는 오브젝트에 스크립트를 추가하여 this.gmaeobject, this.transform으로 접근한다
[2] 하이라키 창에 존재하는 다른 게임 오브젝트(트렌스폼, 컴포넌트)의 인스턴스에 접근하려면
    public으로 객체 변수 선언하고 인스펙터 창에서 드래그로 가져온다

컴포넌트(MonoBehaviour를 상속받는 클래스)의 인스턴스를 가져오는 방법
[1] 게임 오브젝트(트렌스폼)의 인스턴스.GetComponent<>()
[2] public으로 컴포넌트(MonoBehaviour를 상속받는 클래스)의 인스턴스의 멤버변수 선언 후
    인스펙터 창에서 드래그로 가져온다

 
 */
