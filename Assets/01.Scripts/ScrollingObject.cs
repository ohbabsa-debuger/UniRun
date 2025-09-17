using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    // 게임오브젝트를 계속 왼쪽으로 움직이는 스크립트
    public float speed = 10f; //이동속도

    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left *speed *Time.deltaTime);
    }
}
