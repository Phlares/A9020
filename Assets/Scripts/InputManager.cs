using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
	public CreateZone zoneManager;
	public RayCastToMouseTarget rayManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
		zoneManager = transform.gameObject.GetComponent<CreateZone>();
		GameObject rayCastCamera;
		rayCastCamera = GameObject.Find("Main Camera");
    	rayManager = rayCastCamera.GetComponent<RayCastToMouseTarget>();
    }

    // Update is called once per frame
    void Update()
    {

	if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			rayManager.CastRay();
			zoneManager.SetNextLocationToHit();
			zoneManager.AddNextLocationToList();
			zoneManager.SpawnZoneAtLocation();
		}
    }

    
}
