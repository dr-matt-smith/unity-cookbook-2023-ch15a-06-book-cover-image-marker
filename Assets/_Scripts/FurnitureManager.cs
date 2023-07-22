using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class FurnitureManager : MonoBehaviour
{
    public GameObject furniturePrefab;
    private ARRaycastManager _raycastManager;
    public List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Awake()
    {
        _raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(_raycastManager.Raycast(ray, hits))
            {
                Pose pose = hits[0].pose;
                Instantiate(furniturePrefab, pose.position, pose.rotation);
            }
        }
        
    }
    
    
}