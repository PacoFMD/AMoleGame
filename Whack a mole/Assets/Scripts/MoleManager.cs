using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleManager : MonoBehaviour
{
    public Material defaultMat;
    bool status, isHit;
    public float time=0, maxTime;
    public Gamemanager gmManager;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Topo());  
        maxTime = Random.Range(1, 3);
    }

    private void Update()
    {
        if(gmManager.endCorrutine && !gmManager.gameOver)
        {
            time += Time.deltaTime;

            if (time >= maxTime)
            {
                time = 0;
                maxTime = Random.Range(1, 2.5f);
                status = !status ? true : false;

            }
            if (this.gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material.name == "Rojo (Instance)" && status == false)
                ResetGameObject();
            //this.gameObject.GetComponent<MeshRenderer>().enabled = status;
            this.GetComponent<BoxCollider>().enabled = status;
            this.gameObject.transform.GetChild(0).gameObject.SetActive(status);
            //Debug.Log("Objeto: " + this.name + " en status: " + status+ " el color es: "+ this.gameObject.GetComponent<MeshRenderer>().material.name);
        }



    }

    public void IsHit()
    {
        this.GetComponent<BoxCollider>().enabled = false;
        //status = false;
    }

    public void ResetGameObject()
    {

       this.GetComponent<BoxCollider>().enabled = true;
        this.gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material = defaultMat;
    }
}
