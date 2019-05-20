using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vuforia{

public class AtomSpawner : MonoBehaviour, ITrackableEventHandler
{
	public GameObject atom_pref;
	//public GameObject UI_pref;
	private GameObject atom;
	private GameObject UI;
	private bool isShowing;
            private TrackableBehaviour mTrackableBehaviour;
    
      
	 void Start()
        {
            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
        }


    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus){

            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                OnTrackingFound();
            }
            else
            {
                OnTrackingLost();
            }

    }
    private void OnTrackingFound()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Enable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = true;
            }

            // Enable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = true;
            }

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
            atom = (GameObject)Instantiate(atom_pref, gameObject.transform);
            //UI = (GameObject)Instantiate(UI_pref,gameObject.transform);
            //atom = GameObject.FindWithTag(atom_name);
    		 //foreach (Touch touch in Input.touches)
        	//	{
    		/* if (Input.GetKeyDown(KeyCode.I)){
             		isShowing = !isShowing;
        	 		UI.SetActive(isShowing);
        	}*/

           // atom.transform.transform.position = gameObject.transform.position;
            //atom.transform.parent = gameObject.transform;
            //atom.transform.transform.rotation = gameObject.transform.rotation;
            //atom.transform.TransformDirection(Vector3.up);
            //atom.transform.localScale = new Vector3 (1f,1f,1f);
            //UI.transform.transform = gameObject.transform;
            //atom.transform.parent = gameObject.transform;

            //UI.transform.parent = gameObject.transform;
        }

        private void OnTrackingLost()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Disable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = false;
            }

            // Disable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = false;
            }

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost____YEAH");

//Evertime the target lost / no target found it will show “???” on the TextTargetName. Button, Description and Panel will invicible (inactive)

            Destroy(atom);
            //Destroy(UI);
        }


}
}