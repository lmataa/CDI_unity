using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbits : MonoBehaviour
{
	public Transform target;
	public GameObject nucleo;
	public Rigidbody rb;

	public int angularv = 90;
    public float thrust;


    // Start is called before the first frame update
    void Start()
    {
        this.target = nucleo.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = 
    	RotatePointAroundPivot(transform.position, target.position, Quaternion.Euler(0, angularv * Time.deltaTime, 0));
    }

    void FixedUpdate()
    {
        rb.AddForce(transform.forward * thrust);
    }

    void SetTarget(Transform t)
    {
        this.target = t;
    }

    public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Quaternion angle) {
   		return angle * ( point - pivot) + pivot;
	}
}
