using UnityEngine;

public class BackGroundLoop : MonoBehaviour
{
    private float width;  //배경의 가로길이

    private void Awake()
    {
       // BoxCollider2D 컴포넌트의 Size 필드의 X값을 가로 길이로 사용
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.x;
    }


    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -width)

        {
            Reposition();
        }
    }
    //위치를 재배치하는 메서드
    private void Reposition()
    {
        Vector2 offset = new Vector2(width * 2f, 0);
        transform.position = (Vector2) transform.position + offset;

    }
}
