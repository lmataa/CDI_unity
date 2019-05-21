using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for controlling canvas in game for atom, quickfix for third requirement
//Works both in android with tap and in pc with "I"
public class DynamicText : MonoBehaviour
{	

	public GameObject UI1;
	public GameObject atom;
	public string atom_name = "";
	public bool release;
    private bool isShowing;

    void Start()
    {
    	isShowing=false;
    }

    // Update is called once per frame
    void Update()
    {	


    	if(release){
    		atom = GameObject.FindWithTag(atom_name);
    		 if (Input.GetKeyDown(KeyCode.I)&&atom.active){
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
