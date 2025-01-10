using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class MouseClickSystem : MonoBehaviour
{
    [Inject] private DragSystem dragSystem;
    // ��� ����������� ���������� ������� �������.
    private bool _isDrage = false;
    private GameObject lastObject = null;

    private Ray ray;
    private RaycastHit2D hit;

    void Update()
    {
        // ��������� ������� ����
        if (Input.GetMouseButton(0))
        {
            // ���� ��� ���� ������, �� �� �������� ����� �����
            if(_isDrage == false)
            {
                CastRay();
            }
        }
        else
        {
            // ���� ����� �������� ���������� ������� �����
            _isDrage = false;

            if (lastObject != null)
            {
                dragSystem.setRigedbodyObject(lastObject);
                lastObject = null;
            }
            
        }

        if(_isDrage)
        {
            // ���� ����� ������, �� �������� ��� DragSystem
            dragSystem.DragObject(lastObject);
        }
    }

    void CastRay()
    {
        // ������� ��� �� ������ � ������� �����
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

       if(hit)
       {
            // �� ��� ��� ���� ����� ������ �� ����� ��������� � ����� �������.
            lastObject = hit.collider.gameObject;
            _isDrage = true;
       }
    }
}
