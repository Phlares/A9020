using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RayCastToMouseTarget : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
	if (Input.GetKey(KeyCode.Mouse0))
	{
		CastRay();
	}
    }

    void CastRay()
    {
        RaycastHit hit;
        Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
       
        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            Debug.Log("Ray direction is " + ray.direction);
            Debug.DrawRay(ray.origin, (ray.direction * hit.distance) , Color.green, 3f, true);
            Debug.Log("I am shooting a thing at " + hit.collider.gameObject + " at " + ray.GetPoint(objectHit.position.x));
            // Do something with the object that was hit by the raycast.
        }
    }
}
