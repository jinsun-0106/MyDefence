using UnityEngine;

namespace Sample
{
    public class ChairMove : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //의자를 이동하라
            //Debug.Log("앞으로 이동하기");
        }

        public float speed = 5;

        // Update is called once per frame
        void Update()
        {
            //의자를 이동하라
            Debug.Log("앞으로 이동하기");

            //이동은 Start가 아닌 Update에서 해야 함!

            //실제 이동 명령
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }
}
