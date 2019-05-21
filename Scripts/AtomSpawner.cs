using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vuforia{

//Spawner script to instantiate atoms in the ImageTarget objects dynamically, that's why we use
	// ITrackableEventHandler, for overriding the vuforia OnTrackableStateChange
public class AtomSpawner : MonoBehaviour, ITrackableEventHandler
{
	public GameObject atom_pref; // Atom Prefab to instantiate
	//public GameObject UI_pref;
	private GameObject atom; // GameObject holder
	private GameObject UI; //UI holder, unused
	private bool isShowing; // boolean for showing UI, unused
    private TrackableBehaviour mTrackableBehaviour; // override
    
      
     //Needed for override the TrackableBehaviour from vuforia
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

    //When a change of state is detected call OnTrackingFFound and OnTrackingLost
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

    //When object found in scene, instantiate atom prefab in gameObject transform
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

            //Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
            atom = (GameObject)Instantiate(atom_pref, gameObject.transform);
           

            // CONSIDER TO IMPROVE:: UI DYNAMIC INSTANCE HERE WITH ATOM AND LOGIC
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

        //When object lost in scene, destroy the content of atom GameObject
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

            //Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost____YEAH");
            Destroy(atom);
            //Destroy(UI);
        }


}
}