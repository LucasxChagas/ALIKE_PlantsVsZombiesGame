using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelMouse : MonoBehaviour
{

    private Camera mainCamera;
    Collider gridCollider;
    RaycastHit hit;
    Ray ray;

    
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        gridCollider = GameObject.Find("Grid").GetComponent<Collider>();

    }

    void Update()
    {


        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            transform.position = raycastHit.point;
        }

        if (GameManager.currentCharacter == null && !GameManager.removeEnabled)
        {
            Destroy(gameObject);
        }

    }
}
