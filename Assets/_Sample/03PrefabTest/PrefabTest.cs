using UnityEngine;
using System.Collections;


namespace Sample
{
    public class PrefabTest : MonoBehaviour
    {
        #region Variables
        //프리팹 오브젝트
        public GameObject prefab;

        //맵 타입들의 부모 오브젝트
        //public Transform parent;

        //맵 타일 생성 체크
        bool isCreate = false;
        #endregion

        #region Unity Event Method
        void Start ()
        {
            //[1] 
            //Instantiate(prefab);

            //위치: (5, 0, 8)에 맵타일 생성하기
            //Instantiate(prefab, 위치, 방향);
            /*Vector3 position = new Vector3(5f, 0f, 8f);
            Instantiate(prefab, position, Quaternion.identity);*/

            //식 그대로 넣어도 됨
            //Instantiate(prefab, new Vector3(5f, 0f, 8f), Quaternion.identity);

            //행(row) X 열(column) 타일맵 찍기
            //GenerateMap(10, 10);
            //GenerateMapTile(10, 10);

            //랜덤타일 찍기
            //GenerateRandomMapTile();

            //램덤 타일 1초 간격으로 10개 찍는다
            //타일 하나 찍고-> 1초 딜레이 -> 타일 하나 찍고 -> 1초 딜레이 -> ...
           /* Debug.Log("[0] 코루틴 시작");
            StartCoroutine(CreateMapTile());
            Debug.Log("[4] 타일 생성 완료");                  //[0] -> [1] -> [4] -> [2] -> [3]
*/
        }

        private void Update()
        {
            if ( isCreate == false )
            {
                //램덤 타일 1초 간격으로 10개 찍는다
                //타일 하나 찍고-> 1초 딜레이 -> 타일 하나 찍고 -> 1초 딜레이 -> ...
                Debug.Log("[0] 코루틴 시작");
                StartCoroutine(CreateMapTile());
                
                isCreate = true;
                Debug.Log($"[4] 타일 생성 완료: {isCreate}");
            }

            Debug.Log($"[99]업데이트 내용 실행");

        }

        #endregion

        #region Custom Method
        void GenerateMap (int row, int column)
        {
            //10 X 10 타일맵 찍기, 타일 간 간격은 1

            for (var i = 0; i < row; i++)
            {
                
                for (var j = 0; j < column; j++)
                {
                    Vector3 position = new Vector3(i * 5f, 0, j * -5f);
                    Instantiate(prefab, position, Quaternion.identity);
                }

            }


        }

        #endregion

        //맵 제네레이터를 부모로 지정하며 맵 타일 찍기
        #region
        void GenerateMapTile(int row, int column)
        {
            for (var i = 0; i < row; i++)
            {

                for (var j = 0; j < column; j++)
                {
                    //인스턴스 시 위치 지정
                    Vector3 position = new Vector3(i * 5f, 0, j * -5f);
                    Instantiate(prefab, position, Quaternion.identity, this.transform);

                    //인스턴스 후 위치 지정
                    /*GameObject go = Instantiate(prefab, this.transform);
                    go.transform.position = new Vector3(i * 5f, 0, j * -5f);*/

                }

            }
        }

        //행(row)10 X 열(column)10 중에 랜덤한 위치에 타일 하나 찍기
        void GenerateRandomMapTile()
        {
            /*int row = Random.Range(0, 10);
            int column = Random.Range(0, 10);*/

            int randNumber = Random.Range(0, 100);
            int row = randNumber / 10;
            int column = randNumber % 10;
                           
            Vector3 position = new Vector3(row * 5f, 0, column * -5f);
            Instantiate(prefab, position, Quaternion.identity, this.transform);
             
        }

        IEnumerator CreateMapTile ()
        {
            /*GenerateRandomMapTile();
            Debug.Log("[1] 첫번째 타일 생성");
            yield return new WaitForSeconds(1.0f);

            GenerateRandomMapTile();
            Debug.Log("[2] 두번째 타일 생성");
            yield return new WaitForSeconds(1.0f);

            GenerateRandomMapTile();
            Debug.Log("[3] 세번째 타일 생성");
            yield return new WaitForSeconds(1.0f);*/

            for (int i = 0; i < 10; i++)
            {
                GenerateRandomMapTile();
                Debug.Log($"{i + 1}번째 타일 생성");
                yield return new WaitForSeconds(1.0f);

            }
        }


        #endregion



    }
}

/*
코루틴 함수 : 지연 함수

- 하나 이상의 yield return 문이 꼭 있어야 한다
- yield return 문에서 지연 시간 지정한다
- 시간(초) 지연 : yield return new WaitForSeconds(지연시간(초 단위));



형식
IEnumerator 함수이름()
{
    //...
    yield return ..//하나 이상의 yield return 문이 꼭 있어야 한다(없으면 에러)

}


코루틴 함수 호출
StartCoroutine(코루틴함수이름);


 */