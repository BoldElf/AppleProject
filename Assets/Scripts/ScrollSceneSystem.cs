using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollSceneSystem : MonoBehaviour
{
    [SerializeField] private GameObject cameraObject;

    [SerializeField] private float maxOffsetCameraRight = 16.0f;
    [SerializeField] private float maxOffsetCameraLeft = -16.0f;
    [SerializeField] private float scrollSpeed = 200f;

    void Update()
    {
        // Ѕерем данные с колесика мышки и двигаем камеру.
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll > 0f)
        {
            // ѕроверка на лимит передвижени€ камеры
            if(cameraObject.transform.position.x < maxOffsetCameraRight)
            {
                cameraObject.transform.position += new Vector3(scroll * scrollSpeed * Time.deltaTime,0,0);
            }
            else
            {
                cameraObject.transform.position = new Vector3(maxOffsetCameraRight, 0, -10);
            }
            
        }
        else if (scroll < 0f)
        {
            if (cameraObject.transform.position.x > maxOffsetCameraLeft)
            {
                cameraObject.transform.position += new Vector3(scroll * scrollSpeed * Time.deltaTime, 0, 0);
            }
            else
            {
                cameraObject.transform.position = new Vector3(maxOffsetCameraLeft, 0, -10);
            }
        }
    }
}
