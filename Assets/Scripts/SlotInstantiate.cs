using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotInstantiate : MonoBehaviour
{
    public GameObject prefabSlot;
    private GameObject slot;
    
    [SerializeField] float spacingX, spacingZ;
    private float currentX = 11.5f, distanceX;
    private float currentZ = 2.4f, distanceZ;
    private bool newLane = true;
    void Start()
    {
        distanceX = prefabSlot.GetComponent<Renderer>().bounds.size.x + spacingX;
        distanceZ = prefabSlot.GetComponent<Renderer>().bounds.size.z + spacingZ;


        for (int i = 0; i < 36; i++)
        {
            if (i % 9 == 0 && i != 0)
            {
                newLane = true;
                currentZ = slot.transform.position.z - distanceZ;
            }
            if (newLane)
            {
                newLane = false;
                slot = Instantiate(prefabSlot, new Vector3(11.5f, 0, currentZ), Quaternion.identity) as GameObject;

            }
            else 
            {
                slot = Instantiate(prefabSlot, new Vector3(currentX, 0, currentZ), Quaternion.identity) as GameObject;
            }
            currentX = slot.transform.position.x - distanceX; 
            slot.transform.SetParent(transform);
        }
    }


}
