using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class DragSystem : MonoBehaviour
{
    private Rigidbody2D objectRB;

    // Привязываем обьект к мышке и выключаем физику
    public void DragObject(GameObject dragObject)
    {
        // Проверяем на наличие физики
        if(dragObject.TryGetComponent<Rigidbody2D>(out objectRB))
        {
            objectRB.isKinematic = true;
        }

        // Узнаем позицию мышки
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Привязываем обьект
        dragObject.transform.position = Vector2.MoveTowards(dragObject.transform.position, mousePosition,10000 * Time.deltaTime);
    }

    // Возвращаем физику обьекту
    public void setRigedbodyObject(GameObject rigedbodyObject)
    {
        if(rigedbodyObject.TryGetComponent<Rigidbody2D>(out objectRB))
        {
            objectRB.isKinematic = false;
        }
    }
}
