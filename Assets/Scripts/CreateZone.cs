using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateZone : MonoBehaviour
{
	
	public GameObject rayCastCamera;
	public RayCastToMouseTarget rayCastManager;
	public GameObject zonePrefab;
	public Transform[] zoneLocations;
	public Vector3 currentZoneLocation;
	public Transform nextZoneLocation;

	

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
    	rayCastCamera = GameObject.Find("Main Camera");

    	rayCastManager = rayCastCamera.GetComponent<RayCastToMouseTarget>();
    }

    public void SpawnZoneAtLocation()
    {
    	currentZoneLocation = rayCastManager.rayHitLocation;
    	Instantiate(zonePrefab, currentZoneLocation, Quaternion.identity);

    }
}
