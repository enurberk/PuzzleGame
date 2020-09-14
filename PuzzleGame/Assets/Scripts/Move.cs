using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Camera cam;
    GameObject[] shadows;
    Vector2 startPosition;
    void Start()
    {
        cam = GameObject.Find("Camera").GetComponent<Camera>();
        shadows = GameObject.FindGameObjectsWithTag("shadow");
        startPosition = transform.position;
    }

    private void OnMouseDrag()
    {
        Vector3 position = cam.ScreenToWorldPoint(Input.mousePosition);
        position.z = 0;
        transform.position = position;
    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            foreach (GameObject shadow in shadows)
            {
                if(gameObject.name == shadow.name)
                {
                    float distance = Vector3.Distance(shadow.transform.position, transform.position);
                    if(distance <= 1)
                    {
                        transform.position = shadow.transform.position;
                        Destroy(this);
                    }
                    else
                    {
                        transform.position = startPosition;
                    }
                }
            }
        }
    }
}
