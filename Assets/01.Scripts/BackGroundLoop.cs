using UnityEngine;

public class BackGroundLoop : MonoBehaviour
{
    private float width;  //����� ���α���

    private void Awake()
    {
       // BoxCollider2D ������Ʈ�� Size �ʵ��� X���� ���� ���̷� ���
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
    //��ġ�� ���ġ�ϴ� �޼���
    private void Reposition()
    {
        Vector2 offset = new Vector2(width * 2f, 0);
        transform.position = (Vector2) transform.position + offset;

    }
}
