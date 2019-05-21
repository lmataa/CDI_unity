using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Script for controlling canvas in game for molecule, quickfix for third requirement
//Works both in android with tap and in pc with "I"
public class DynamicTextMolecule : MonoBehaviour
{	


	public GameObject UI1;
	public GameObject molecule;
	private bool isShowing;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    	foreach (Touch touch in Input.touches){
        		if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
                {
	        		if(molecule.active){
	        			isShowing = !isShowing;
	        	 		UI1.SetActive(isShowing);
	        		}
	        	}
        	}

        if (Input.GetKeyDown(KeyCode.I) && molecule.active)
        {
            isShowing = !isShowing;
        	UI1.SetActive(isShowing);
        }
        if(!molecule.active && isShowing){
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
