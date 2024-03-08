using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Start()
    {
        GameObject obj1 = GameObject.Find("�̸�");  // �̸�����ã��
        GameObject obj2 = GameObject.FindWithTag("tag"); // �±׷�ã�� - �Լ� �̸��� �ٿ� ���� ��
        GameObject obj3 = GameObject.FindGameObjectWithTag("tag"); //�±׷�ã��
        GameObject[] obj4 = GameObject.FindGameObjectsWithTag("tag");  //���� �±� ��� ã��
        GameObject obj5 = GameObject.FindAnyObjectByType<GameObject>(); // Ư��Ÿ������ ã��(�ƹ��ų� 1����. ���� ������ ����Ұ���, FindFirstObjectByType���� ������.)
        GameObject obj6 = GameObject.FindFirstObjectByType<GameObject>();   // Ư��Ÿ������ ã��(Ÿ���� ù��°)

        // Ư��Ÿ�� ��� ã��(�Ķ���ͷ� ��Ȱ��ȭ�� ������Ʈ �������� ��������)
        GameObject[] obj7 = GameObject.FindObjectsByType<GameObject>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);

        // FindObjectOfType : �����

        // ������Ʈ ã��
        Transform t = GetComponent<Transform>();    // = this.transform;

        // ������Ʈ �߰��ϱ�
        this.gameObject.AddComponent<Test>();

        //���ҽ� ���� ��ˤ��ϱ�
        Texture texture = Resources.Load<Texture>("grass-texture-26");
        Sprite sp = Resources.Load<Sprite>("AAA/grass-sprite");
    }

    private void Update()
    {
        
    }

}
