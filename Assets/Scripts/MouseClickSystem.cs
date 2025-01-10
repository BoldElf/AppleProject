using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class MouseClickSystem : MonoBehaviour
{
    [Inject] private DragSystem dragSystem;
    // Для отслеживния нахождения нужного обьекта.
    private bool _isDrage = false;
    private GameObject lastObject = null;

    private Ray ray;
    private RaycastHit2D hit;

    void Update()
    {
        // Проверяем зажатие мыши
        if (Input.GetMouseButton(0))
        {
            // Если уже есть обьект, то не пытаемся найти новый
            if(_isDrage == false)
            {
                CastRay();
            }
        }
        else
        {
            // Если мышка отпущена возвращаем обьекту физку
            _isDrage = false;

            if (lastObject != null)
            {
                dragSystem.setRigedbodyObject(lastObject);
                lastObject = null;
            }
            
        }

        if(_isDrage)
        {
            // Если нашли обьект, то передаем его DragSystem
            dragSystem.DragObject(lastObject);
        }
    }

    void CastRay()
    {
        // Создаем луч из камеры в позицию мышки
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

       if(hit)
       {
            // До тех пор пока мышка зажата мы будем привязаны к этому обьекту.
            lastObject = hit.collider.gameObject;
            _isDrage = true;
       }
    }
}
