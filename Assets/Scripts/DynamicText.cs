using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicText : MonoBehaviour
{	

	public GameObject UI1;
	public GameObject atom;
	public string atom_name = "";
	public bool release;
    private bool isShowing;
    //public string guiText = "";
   
    void Start()
    {
    	isShowing=false;
    	//gameObject.canvas
    	//gameObject.GetComponent<Canvas>().SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {	


    	if(release){
    		atom = GameObject.FindWithTag(atom_name);
    		 //foreach (Touch touch in Input.touches)
        		//{
    		 if (Input.GetKeyDown(KeyCode.I)&&atom.active){
        		//if(atom.active){
             		isShowing = !isShowing;
        	 		UI1.SetActive(isShowing);
        	}

        	foreach (Touch touch in Input.touches){
        		if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
                {
	        		if(atom.active){
	        			isShowing = !isShowing;
	        	 		UI1.SetActive(isShowing);
	        		}
	        	}
        	}


        }else if (Input.GetKeyDown(KeyCode.I)&&atom.active)
        {
             isShowing = !isShowing;
        	 UI1.SetActive(isShowing);
        }

        if(Input.GetKeyDown(KeyCode.R)){
        	UI1.SetActive(false);
        }

    }
    

    void OnGUI()
    {

    }

}
