using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicTextMolecule : MonoBehaviour
{	

	public GameObject UI1;
	public GameObject molecule;
	//public GameObject otherUI;

    private bool isShowing;
    //public string guiText = "";
    
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
