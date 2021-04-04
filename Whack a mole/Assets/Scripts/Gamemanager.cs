using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;
using UnityEngine.UI;
public class Gamemanager : MonoBehaviour
{
    //public ImageTargetBehaviour[] misImagenes;
    public int count = 0;
    public Text txtContador;

    // Start is called before the first frame update
    void Start()
    {
        //TrackableBehaviour mbTrack = misImagenes[0].GetComponent<TrackableBehaviour>();
        
    }

    // Update is called once per frame
    void Update()
    {

        txtContador.text = count.ToString();

    }


    private bool isTrackingMarker(string imageName)
    {
        GameObject imageTarget = GameObject.Find(imageName);
        TrackableBehaviour trackable = imageTarget.GetComponent<TrackableBehaviour>();
        return trackable.CurrentStatus == TrackableBehaviour.Status.TRACKED;
    }



    public void OnTargetFoundCounter()
    {
        count++;
    }

    public void OnTargetLostCounter()
    {
        count--;
    }
}
