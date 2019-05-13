using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//The main idea behind this script is to instantiate electrons
//according to the elements in a certain postion according to 
//the energy of the atom
public class Holder : MonoBehaviour
{
	public GameObject electron; // prefab electron
	public int electron_num; // number of electrons to have
	private  List<GameObject> electron_holder; //holder of prefabs to instantiate
    // Start is called before the first frame update
    void Start()
    {
    	electron_holder = new List<GameObject>();
    	 for (int i= 0; i < electron_num; i++)
        {
            GameObject obj = (GameObject)Instantiate(electron);
            obj.SetActive(false);
            electron_holder.Add(obj);
        }
        Invoke("spawner",0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //float dist = Vector3.Distance(other.position, transform.position);

    // Let's get funky with the electrons
    void spawner()
    {
    	 for(int i = 0; i < electron_holder.Count; i++)
        {
        	electron_holder[i].SetActive(true);

        	Orbits orbit = electron_holder[i].GetComponent<Orbits>();
        	orbit.nucleo = gameObject;
        	Vector3 origin = gameObject.transform.position;
        	//orbit.target = transform;

        	if(i==0){ 		//LEVEL K
        		electron_holder[i].transform.position = (Vector3.right)/3 + (origin);
        	}
        	else if(i==1){
        		electron_holder[i].transform.position = -(Vector3.right)/3 + (origin);
        	}
        	else if(i<=9){ // LEVEL L
        		electron_holder[i].transform.position =  (Vector3.forward)*2/3 + (origin); 
        	}else{ 			//LEVEL M
        		electron_holder[i].transform.position = (Vector3.forward) + (origin); 
        	}


        }

    }
}
