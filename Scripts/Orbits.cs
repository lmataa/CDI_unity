using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Orbit class for electrons so they can orbit the nuclei in layers,
//each layer will have a particular velocity so the animation will feel less boring.
public class Orbits : MonoBehaviour
{
	public Transform target; // Target
	public GameObject nucleo; // Target 
	public float RotationSpeed = 90f; // For rotation calculations
	public float DesiredDistance;  // For calculations with distances to next frame
	public float OrbitSpeed = 50f; // Default speed
    public float radius; // Radius at where to orbit, distance to nucleo
    public int layer; // Orbit for velocity
	// public float thrust; // Inertia, unused
    // Start is called before the first frame update
    void Start()
    {
        this.target = nucleo.transform;
        DesiredDistance = Vector3.Distance(target.position, transform.position);
    }

    // Update is called once per frame
    void Update()
    {

    	// Animation speed changes over layer, the farther the faster.
    	switch(layer){
    		case 1:
    			OrbitSpeed = 50f;
    			break;
    		case 2: 
    			OrbitSpeed = 100f;
    			break;
    		case 3:
    			OrbitSpeed = 150f;
    			break;
    		default:
    			break;
    	}

		transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime);
        transform.RotateAround(target.position,transform.TransformDirection(Vector3.up), OrbitSpeed * Time.deltaTime);

        //fix possible changes in distance
        float currentDistance = Vector3.Distance(target.position, transform.position);
        Vector3 towardsTarget = transform.position - target.position;
        transform.position += (DesiredDistance - currentDistance) * towardsTarget.normalized;
    }

    void FixedUpdate()
    {
      //  rb.AddForce(transform.forward * thrust); // Inertia, for further development
    }

    public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Quaternion angle) {
   		return angle * ( point - pivot) + pivot;
	}
}
