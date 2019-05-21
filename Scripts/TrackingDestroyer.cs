using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

//For gamescene with atom animation, same as Tracking.cs but with dynamic instantiation
public class TrackingDestroyer : MonoBehaviour
{

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

	public GameObject H2O;
	public GameObject CO2;
	public GameObject CO;
	public GameObject NaCl;
	public GameObject CH4;
	public GameObject NH3;

	private GameObject Oxygen;
	private GameObject Hydrogen;
	private GameObject Carbon;
	private GameObject Sodium;
	private GameObject Nitrogen;
	private GameObject Clorum;




	string guiText = "";
    // Start is called before the first frame update
    void Start()
    {	
        H2O.GetComponent<MeshRenderer>().enabled =false;
        CO.GetComponent<MeshRenderer>().enabled =false;
        CO2.GetComponent<MeshRenderer>().enabled =false;
        NaCl.GetComponent<MeshRenderer>().enabled =false;
        CH4.GetComponent<MeshRenderer>().enabled =false;
        NH3.GetComponent<MeshRenderer>().enabled =false;
    }

    // Update is called once per frame
    void Update()
    {

		//Gather atoms
		Oxygen = GameObject.FindWithTag("Oxygen");
		Hydrogen = GameObject.FindWithTag("Hydrogen");
		Carbon = GameObject.FindWithTag("Carbon");
		Sodium = GameObject.FindWithTag("Sodium");
		Nitrogen = GameObject.FindWithTag("Nitrogen");
		Clorum = GameObject.FindWithTag("Chlorine");

		//Calculate distance for molecules
        float distance_h2o = Vector3.Distance (der.transform.position, Hydrogen_izq.transform.position);
        float distance_co2 = Vector3.Distance (der.transform.position, Carbon_izq.transform.position);
        float distance_nacl = Vector3.Distance (Sodium_der.transform.position, Clorum_izq.transform.position);
        float distance_ch4 = Vector3.Distance (Carbon_der.transform.position, Hydrogen_izq.transform.position);
        float distance_nh3 = Vector3.Distance (Nitrogen_der.transform.position, Hydrogen_izq.transform.position);


		//ON/OFF PART
        if (0.7 > distance_h2o) //H2O
        {
    		H2O.SetActive(true);
    		Destroy(Oxygen);
    		Destroy(Hydrogen);
        }else{
        	H2O.SetActive(false);
        }
        if (0.7 > distance_co2) //CO2
        {
    		CO2.SetActive(true);
    		Destroy(Oxygen);
    		Destroy(Carbon);
        }else{
        	CO2.SetActive(false);
        }
		 if (0.7 > distance_nacl) //NaCl
        {
        	NaCl.SetActive(true);
        	Destroy(Sodium);
        	Destroy(Clorum);
        }else{
        	NaCl.SetActive(false);
        }


        if (0.7 > distance_ch4)	//CH4
        {
        	CH4.SetActive(true);
        	Destroy(Carbon);
        	Destroy(Hydrogen);
        }else{
        	CH4.SetActive(false);
        }

        if (0.7 > distance_nh3) //NH3
        {
        	NH3.SetActive(true);
        	Destroy(Nitrogen);
        	Destroy(Hydrogen);
        }else{
        	NH3.SetActive(false);
        }

    }

}