using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class XR_Placement : MonoBehaviour
{
    //[SerializeField] private GameObject prefab;
    [SerializeField] private List<GameObject> prefabs;
    private List<GameObject> spawnedPrefabs;
    private ARRaycastManager raycastManager;

    // Start is called before the first frame update
    void Start()
    {
       raycastManager = GetComponent<ARRaycastManager>();

       //Added by Sky 
       spawnedPrefabs = new List<GameObject>();
    }

    void ARRaycasting(Vector2 pos)
    {
        List<ARRaycastHit> hits = new();
        if (raycastManager.Raycast(pos, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneEstimated))
        {
            Pose pose = hits[0].pose;
            ARInstantiation(pose.position, pose.rotation);

        }
    }

    void ARInstantiation(Vector3 pos, Quaternion rot)
    {
        // spawnedPrefabs.Add(Instantiate(prefab, pos, rot));
         
        // 모든 prefab 인스턴스화
        foreach (GameObject prefab in prefabs)
        {
            spawnedPrefabs.Add(Instantiate(prefab, pos, rot));
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(index:0);
            Vector2 touchPosition = touch.position;
            ARRaycasting(touchPosition);
        }
        // else if (Input.GetMouseButtonDown(0))
        // {
        //     Vector3 mousePos = Input.mousePosition;
        //     Vector2 mousePos2D = new Vector2(mousePos.x , mousePos.y);
        //     ARRaycasting(mousePos2D);
        // }
    }
}
