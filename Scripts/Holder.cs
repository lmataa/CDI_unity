using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//The main idea behind this script is to instantiate electrons
//according to the elements in a certain postion according to 
//the energy of the atom. Also instantiate protons an neutrons and spin them dynamically.
public class Holder : MonoBehaviour
{

	//Input, consider for future constructor
	public GameObject electron; // prefab electron
	public GameObject proton; // prefab proton
	public GameObject neutron; //prefab neutron
	public int electron_num; // number of electrons to hold
	public int proton_num; // number of protons to hold 
	public int neutron_num; // number of neutrons to hold
	private List<GameObject> electron_holder; //holder of prefabs to instantiate
	private List<GameObject> proton_holder;
    private List<GameObject> neutron_holder;
    private Vector3 nucleus_scale; // inside nucleus scale
    private float nucleus_radius; // spawn radius


    // Game Objects instantiation dynamically, make them child of this GO.
    void Start()
    {
    	nucleus_scale = new Vector3(0.5f, 0.5f, 0.5f)/1.5f;
    	nucleus_radius = 5f;
    	electron_holder = new List<GameObject>();
    	proton_holder = new List<GameObject>();
    	neutron_holder = new List<GameObject>();

    	 for (int i= 0; i < electron_num; i++)
        {
            GameObject obj = (GameObject)Instantiate(electron);
            obj.transform.localScale = nucleus_scale/2;
            obj.SetActive(false);
            electron_holder.Add(obj);
        }
        
        for (int i = 0; i < proton_num; i++){
        	Vector3 position = castRandomVector();
        	GameObject obj = (GameObject)Instantiate(proton);
        	obj.transform.parent = gameObject.transform;
        	obj.transform.position = position;
        	obj.transform.localScale = nucleus_scale;
        	obj.SetActive(false);
        	proton_holder.Add(obj);
        }

        for (int i = 0; i < neutron_num; i++){
        	Vector3 position = castRandomVector();
        	GameObject obj = (GameObject)Instantiate(neutron);
        	obj.transform.parent = gameObject.transform;
        	obj.transform.position = position;
        	obj.transform.localScale = nucleus_scale;
        	obj.SetActive(false);
        	neutron_holder.Add(obj);
  
        }

        Invoke("spawner",0.5f);	
    }

    // Spin to all particles in nucleus, even more funky.
    void Update()
    {
    	transform.Rotate(Vector3.up, 100 * Time.deltaTime);
    }

    // Let's get funky with the particles
    void spawner()
    {
    	//Electrons
    	 for(int i = 0; i < electron_holder.Count; i++)
        {
        	electron_holder[i].SetActive(true);
        	Orbits orbit = electron_holder[i].GetComponent<Orbits>();
        	orbit.nucleo = gameObject;
        	electron_holder[i].transform.parent = gameObject.transform; 
        	electron_holder[i].transform.position = segment_switch(i, orbit);
        }

        //Nucleus
	        for(int i = 0; i<neutron_num;i++){
	        	nuclear_init(i);
	        }
	        if(neutron_num==0&& proton_num!=0){
	    		nuclear_init(0);
	        }
    }

    //Subfunction to init the nucleus, activate protons and neutrons and reference them to the nucleus
    void nuclear_init(int i){
    	if(i<proton_num && i< neutron_num){
    		if(i%2==0){
	    		proton_holder[i].SetActive(true);
	    		neutron_holder[i].SetActive(true);
	    		NuclearGravity ng = proton_holder[i].GetComponent<NuclearGravity>();
	    		ng.nucleo = gameObject;
	    		NuclearGravity ng2 = neutron_holder[i].GetComponent<NuclearGravity>();
	    		ng2.nucleo = gameObject;
    		} else{
	    		neutron_holder[i].SetActive(true);
	    		proton_holder[i].SetActive(true);
	    		NuclearGravity ng2 = neutron_holder[i].GetComponent<NuclearGravity>();
	    		ng2.nucleo = gameObject;
	    		NuclearGravity ng = proton_holder[i].GetComponent<NuclearGravity>();
	    		ng.nucleo = gameObject;

    		}
    	}else if (i>proton_num && i<neutron_num){
    		neutron_holder[i].SetActive(true);
        	NuclearGravity ng = neutron_holder[i].GetComponent<NuclearGravity>();
    		ng.nucleo = gameObject;
    	}else if(i<proton_num && i==neutron_num){
    		proton_holder[i].SetActive(true);
        	NuclearGravity ng = proton_holder[i].GetComponent<NuclearGravity>();
    		ng.nucleo = gameObject;
    	}
    }

    //Asing position to electrons, equidistant, set layer, return position
    Vector3 segment_switch(int i ,Orbits o){
    	Vector3 origin = gameObject.transform.position;
    	float r_scale = 0.5f;
    	Vector3 first = Vector3.right/r_scale;
    	Vector3 director = Vector3.right;
    	Orbits orbit = electron_holder[i].GetComponent<Orbits>();

    	/************************* LEVEL K ***************************/
    	switch(i){ 
    		case 0:
        		orbit.layer = 1;
    			return (first) + (origin);
    			break;
    		case 1:
        		orbit.layer = 1;
    			return -(first) + (origin);
    			break;
    		default:
    			break;
    		}
    	/************************* LEVEL L ***************************/
    	if (i>1 && i<10){
    		int level_l = electron_num-2;
    		if(level_l >= 8) level_l = 8;
    		float arc = 360/level_l;
    		i = i-1;
    		if( arc*i == 360){
    			arc = 0;
    		}
    		var rot = Quaternion.AngleAxis(arc*i,Vector3.up);
			director = rot * first*2 + origin;
        	orbit.layer = 2;
        /************************* LEVEL M ***************************/
    	}else{ 
    		int level_m = electron_num-10;
    		float arc = 360/level_m;
    		i = i-9;
    		var rot = Quaternion.AngleAxis(arc*i,Vector3.up);
    		director = rot * first*3 + origin;
        	orbit.layer = 3;
    	}
    	return director;

    	}

    	//Getters and setters, may be unused.
    	public List<GameObject> getElectrons(){
    		return this.electron_holder;
    	}

    	public List<GameObject> getProtons(){
    		return this.proton_holder;
    	}

    	public List<GameObject> getNeutrons(){
    		return this.neutron_holder;
    	}
    	//for instantiating a particle around nuclei
    	private Vector3 castRandomVector(){
    		return new Vector3(gameObject.transform.position.x+Random.Range(-nucleus_radius,nucleus_radius), gameObject.transform.position.y+Random.Range(-nucleus_radius,nucleus_radius), gameObject.transform.position.z+Random.Range(-nucleus_radius,nucleus_radius));
    	}
 	 } 

