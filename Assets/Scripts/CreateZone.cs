using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateZone : MonoBehaviour
{
	
	public GameObject rayCastCamera;
	public RayCastToMouseTarget rayCastManager;
	public GameObject zonePrefab;
	public List<Vector3> zoneLocations;
	public Vector3 currentZoneLocation;
	public Vector3 nextZoneLocation;

	
	//zoneLocations: To manage location, 0 will be previous location, 1 will be current location, and 2 will be next location.

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
    	//Create our List
    	List<Vector3> zoneLocations = new List<Vector3>();
    	
    }

    public void SpawnZoneAtLocation()
    {
    	//Null if there was no previous list, or if the list is reset.
    	if (zoneLocations[0] == null)
    	{
    		Instantiate(zonePrefab, currentZoneLocation, Quaternion.identity);
    		zoneLocations.Add(currentZoneLocation); //Sets 0 index
    		zoneLocations.Add(currentZoneLocation); //Sets 1 index
    		//We run this twice to achieve L16 rule: 0 previous location, 1 current location.
    	}
    	if (zoneLocations[1] != null){

    	}


    }

    public void AddNextLocationToList()
    {
    	// Code to handle List Elements
    	//Check if we are already at our next location
    	if (zoneLocations[2] == zoneLocations[1]) //This code should run if and only if the player moves to the exact same location, that case, pull the next location from the list.=
    	{
    			Debug.Log("Trying to remove " + zoneLocations[2] + " from the list");
    			zoneLocations.RemoveAt(2);
    	}
    	if (zoneLocations[2] == null) // This code will run when there is a current location at [1], but not a next location, if zoneLocations[1] is the same as next location, do nothing.
    	{
    		if (zoneLocations[1] == nextZoneLocation)
    		{
    			Debug.Log("The next location would be the current location, do not set a new location.");
    		}
    		else if (zoneLocations[1] != nextZoneLocation) {
    			Debug.Log("There was no nextlocation at index 2, setting " + nextZoneLocation + " to next location");
    			zoneLocations[2] = nextZoneLocation; // No next location (such as first start)
    			
    		}
    	else if (zoneLocations[2] != null)
    		{
    			Debug.Log("Trying to add " + nextZoneLocation + " as next location");
    			zoneLocations.Add(nextZoneLocation); // Add next location to top of stack, Index [3]
    			zoneLocations.RemoveAt(0); // Remove history FILO

    			ReadList();
    		}

    	}
    	
    }
    public void ReadList()
    {
    	Debug.Log(zoneLocations[0] + " is the previous location");
    	Debug.Log(zoneLocations[1] + " is the current location");
    	Debug.Log(zoneLocations[2] + " is the next location");	
    }

    public void SetNextLocationToHit()
    {
    	nextZoneLocation = rayCastManager.rayHitLocation;
    }

    public void SetNextZone()
    {
    	// Check whether there is a current zone
    	// If there is a current zone, set the next zone
    	// When the current zone == next zone, exit
    	// When there is a new command, set the next location to current location, and set new location as next location--> NTH for movement, it will be nice to do a momentum type function: It will need some work, seems tricky: Force will certainly have some quirkiness, Lerp won't be smooth, move will be robotic, translate too.
    	// 
    	// 
    }

}
