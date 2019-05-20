using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Orbit class for electrons so they can orbit the nuclei in layers,
//each layer will have a particular velocity so the animation will feel less boring.
public class Orbits : MonoBehaviour
{
	public Transform target;
	public GameObject nucleo;
	public float RotationSpeed = 90f;
	public float DesiredDistance;
    public float thrust;
	public float OrbitSpeed = 50f;
    public float radius;
    public int layer;

    // Start is called before the first frame update
    void Start()
    {
        this.target = nucleo.transform;
        DesiredDistance = Vector3.Distance(target.position, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
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
      //  rb.AddForce(transform.forward * thrust);
    }
/*
    void SetTarget(Transform t)
    {
        this.target = t;
    }
*/
    public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Quaternion angle) {
   		return angle * ( point - pivot) + pivot;
	}
}
