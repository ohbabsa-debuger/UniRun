using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    // ���ӿ�����Ʈ�� ��� �������� �����̴� ��ũ��Ʈ
    public float speed = 10f; //�̵��ӵ�

    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left *speed *Time.deltaTime);
    }
}
