using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;
using UnityEngine.UI;
public class Gamemanager : MonoBehaviour
{
    public Material hitMaterial;
    float timeLeft = 60.0f;
    public int count = 0, objInScene = 0;
    public Text txtCounter, txtTime;
    public GameObject Texto1, Texto2, txtEndGame;
    public bool gameOver, endCorrutine;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        endCorrutine = false ;
    }

    // Update is called once per frame
    void Update()
    {

        if(objInScene == 3) //si estan los 3 targets en escena
        {
            if(!endCorrutine)
            {
                StartCoroutine(StartGame());
            }
            else
            {
                timeLeft -= (Time.deltaTime*2);
                txtTime.text = "Tiempo: "+timeLeft.ToString();
                if (timeLeft <= 0)
                    gameOver = true;

                if (gameOver)
                {
                    txtTime.text = "Tiempo: 0";
                    txtEndGame.SetActive(true);
                }
                else
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                        RaycastHit hitInfo;
                        if (Physics.Raycast(ray, out hitInfo))
                        {
                            hitInfo.collider.transform.GetChild(0).transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material = hitMaterial;
                            hitInfo.collider.GetComponent<BoxCollider>().enabled = false;
                            count++;
                        }
                    }

                }

                txtCounter.text = "Puntuacion: "+count.ToString();
            }

        }

    }


    private bool isTrackingMarker(string imageName)
    {
        GameObject imageTarget = GameObject.Find(imageName);
        TrackableBehaviour trackable = imageTarget.GetComponent<TrackableBehaviour>();
        return trackable.CurrentStatus == TrackableBehaviour.Status.TRACKED;
    }



    public void OnTargetFoundCounter()
    {
        objInScene++;
    }
    

    IEnumerator StartGame()
    {
        Texto1.SetActive(true);
        yield return new WaitForSeconds(2);
        Texto1.SetActive(false);
        Texto2.SetActive(true);
        yield return new WaitForSeconds(2);
        Texto2.SetActive(false);
        endCorrutine = true;
    }

}
