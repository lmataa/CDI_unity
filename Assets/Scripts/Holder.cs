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

        	//orbit.target = transform;
        	electron_holder[i].transform.position = segment_switch(i);
        	/*
        	//LEVEL K ---------------------
        	if(i==0){ 		
        		electron_holder[i].transform.position = //(Vector3.right)/3 + (origin);
        	}
        	else if(i==1){
        		electron_holder[i].transform.position = -(Vector3.right)/3 + (origin);
        	}

        	//LEVEL L ----------------------------------
        	if(i>2){
        		electron_holder[i].transform.position =  (Vector3.forward)*2/3 + (origin); 
        	}else{ 			//LEVEL M
        		electron_holder[i].transform.position = (Vector3.forward)*2/3 + (origin); 
        	}

        	//LEVEL M ------------------------------------------
        	if(i==10){
        		electron_holder[i].transform.position =  (Vector3.forward)*2/3 + (origin); 
        	}else{ 			//LEVEL M
        		electron_holder[i].transform.position = (Vector3.forward) + (origin); 
        	}
*/

        }

    }

    Vector3 segment_switch(int i){
    	Vector3 origin = gameObject.transform.position;
    	int r_scale = 3;
    	Vector3 first = Vector3.right/r_scale;
    	Vector3 director = Vector3.right;
    	switch(i){ //LEVEL K
    		case 0:
    			return (first) + (origin);
    			break;
    		case 1:
    			return -(first) + (origin);
    			break;
    		default:
    			break;
    		}
    	if (i>1 && i<10){ //LEVEL L
    		int level_l = electron_num-2;
    		if(level_l >= 8) level_l = 8;
    		float arc = 360/level_l;
    		i = i-1;
    		
    		if( arc*i == 360){
    			arc = 0;
    		}

			Debug.Log(i);
    		Debug.Log(arc*i);

    		var rot = Quaternion.AngleAxis(arc*i,Vector3.up);
			// that's a local direction vector that points in forward direction but also 45 upwards.
			director = rot * first*2 + origin;
			
			//direction*2/3;
    	}else{ // LEVEL M
    		int level_m = electron_num-10;
    		float arc = 360/level_m;
    		i = i-9;
    		var rot = Quaternion.AngleAxis(arc*i,Vector3.up);
    		director = rot * first*3 + origin;

    	}
    	return director;
    	//return new Vector3(0,0,0);
    	}


    }

