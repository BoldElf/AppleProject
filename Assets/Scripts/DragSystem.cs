using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class DragSystem : MonoBehaviour
{
    private Rigidbody2D objectRB;

    // ����������� ������ � ����� � ��������� ������
    public void DragObject(GameObject dragObject)
    {
        // ��������� �� ������� ������
        if(dragObject.TryGetComponent<Rigidbody2D>(out objectRB))
        {
            objectRB.isKinematic = true;
        }

        // ������ ������� �����
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // ����������� ������
        dragObject.transform.position = Vector2.MoveTowards(dragObject.transform.position, mousePosition,10000 * Time.deltaTime);
    }

    // ���������� ������ �������
    public void setRigedbodyObject(GameObject rigedbodyObject)
    {
        if(rigedbodyObject.TryGetComponent<Rigidbody2D>(out objectRB))
        {
            objectRB.isKinematic = false;
        }
    }
}
