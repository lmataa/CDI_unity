using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Simple molecule scalator
public class Molecule	 : MonoBehaviour
{
	public float radius;
    // Start is called before the first frame update
    void Start()
    {
         gameObject.transform.localScale = new Vector3(radius,radius,radius)*4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
