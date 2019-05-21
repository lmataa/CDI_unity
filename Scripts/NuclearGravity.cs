using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Script to create a blob of particles in the space of the nucleus of an atom.
//Will be assigned to nuclei particles as protons or neutrons.
public class NuclearGravity : MonoBehaviour
{
	public GameObject nucleo; //Nucleo gameobjet for moving there
    public float G_const = 0.3f; //acceleration

    void Start()
    {
        //Just checking everything is in place with velocity at Start;
     GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // And in every update (overrided by fixedUpdate)
        GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
        //transform.Rotate(new Vector3(0.0f, 0.0f, 0.0f), Time.deltaTime);

    }

    public void FixedUpdate()
    {

        //Constant velocity towards the core
       // if(GetComponent<Rigidbody>().velocity.magnitude<=0.2f) {
            GetComponent<Rigidbody>().velocity += G_const  * (nucleo.transform.position - transform.position);//* Time.fixedTime
        //}else{
                
          //  }
    }

    public void nuclear_init(GameObject n){
        this.nucleo = n;
    }
}
