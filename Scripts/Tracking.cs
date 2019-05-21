using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

//SImple distance calculator for instantiating molecules when imagetargets together.
public class Tracking : MonoBehaviour
{

	//edges of cards 
	public GameObject izq;
	public GameObject der;

	public GameObject Hydrogen_izq;
	public GameObject Hydrogen_der;

	public GameObject Carbon_izq;
	public GameObject Carbon_der;

	public GameObject Nitrogen_izq;
	public GameObject Nitrogen_der;

	public GameObject Sodium_izq;
	public GameObject Sodium_der;

	public GameObject Clorum_izq;
	public GameObject Clorum_der;

	//molecules
	public GameObject H2O;
	public GameObject CO2;
	//public GameObject CO;
	public GameObject NaCl;
	public GameObject CH4;
	public GameObject NH3;
	
	// atom holders
	public GameObject Oxygen;
	public GameObject Hydrogen;
	public GameObject Carbon;
	public GameObject Sodium;
	public GameObject Nitrogen;
	public GameObject Clorum;

	string guiText = "";
    // Start is called before the first frame update
    void Start()
    {	
        H2O.GetComponent<MeshRenderer>().enabled =false;
        //CO.GetComponent<MeshRenderer>().enabled =false;
        CO2.GetComponent<MeshRenderer>().enabled =false;
        NaCl.GetComponent<MeshRenderer>().enabled =false;
        CH4.GetComponent<MeshRenderer>().enabled =false;
        NH3.GetComponent<MeshRenderer>().enabled =false;
    }

    // Update is called once per frame
    void Update()
    {



    	//DUPLICATE FOR CONSIDERING BOTH EDGES OF THE IMAGETARGET
        float distance_h2o = Vector3.Distance (der.transform.position, Hydrogen_izq.transform.position);
        float distance_co2 = Vector3.Distance (der.transform.position, Carbon_izq.transform.position);
        float distance_nacl = Vector3.Distance (Sodium_der.transform.position, Clorum_izq.transform.position);
        float distance_ch4 = Vector3.Distance (Carbon_der.transform.position, Hydrogen_izq.transform.position);
        float distance_nh3 = Vector3.Distance (Nitrogen_der.transform.position, Hydrogen_izq.transform.position);

        //ON PART

         if (distance_nh3 > 1) {  //nh3 -check
			
        	Nitrogen.SetActive(true);
        	Hydrogen.SetActive(true);
		}

        if (distance_h2o > 1) {  //H2O - check
			
        	Oxygen.SetActive(true);
        	Hydrogen.SetActive(true);
		}

         if (distance_co2 > 1) {  //CO2 - check
			
        	Oxygen.SetActive(true);
        	Carbon.SetActive(true);
		}

        if (distance_nacl > 1) {  //NaCl - check
			
        	Sodium.SetActive(true);
        	Clorum.SetActive(true);
		}

         if (distance_ch4 > 1) {  //CH4 - check
			
        	Carbon.SetActive(true);
        	Hydrogen.SetActive(true);
		}

		//OFF PART
        if (0.7 > distance_h2o) //H2O
        {

        	Oxygen.SetActive(false);
        	Hydrogen.SetActive(false);
        }
        if (0.7 > distance_co2) //CO2
        {

        	Oxygen.SetActive(false);
        	Carbon.SetActive(false);
        }

		 if (0.7 > distance_nacl) //NaCl
        {

        	Clorum.SetActive(false);
        	Sodium.SetActive(false);
        }


        if (0.7 > distance_ch4)	//CH4
        {

        	Carbon.SetActive(false);
        	Hydrogen.SetActive(false);
        }


        if (0.7 > distance_nh3) //NH3
        {

        	Nitrogen.SetActive(false);
        	Hydrogen.SetActive(false);
        }

        //RENDER MOLECULE
        if(!Oxygen.activeSelf && !Hydrogen.activeSelf){ //H2O - check
        	
        	H2O.SetActive(true);
        }else{
        	H2O.SetActive(false);
        }

        if(!Oxygen.activeSelf && !Carbon.activeSelf){ //CO2
        	
        	CO2.SetActive(true);
        }else{
        	CO2.SetActive(false);
        }

        if(!Sodium.activeSelf && !Clorum.activeSelf){ //NaCl
        	
        	NaCl.SetActive(true);
        }else{
        	NaCl.SetActive(false);
        }

        if(!Carbon.activeSelf && !Hydrogen.activeSelf){ //CH4
        	
        	CH4.SetActive(true);
        }else{
        	CH4.SetActive(false);
        }       

        if(!Nitrogen.activeSelf && !Hydrogen.activeSelf){ //NH3
        	
        	NH3.SetActive(true);
        }else{
        	NH3.SetActive(false);
        }
		
    }
}