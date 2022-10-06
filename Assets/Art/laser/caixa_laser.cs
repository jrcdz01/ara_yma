using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class caixa_laser : MonoBehaviour
{
    public Transform projetil;
    public Transform pivot;
    public float respawnTime = 1.0f;
    
    // Start is called before the first frame update
    void Start(){
        StartCoroutine( laserWave() );
    }

    private void spanwProjetil(){
        Instantiate(projetil, pivot);
    }

    IEnumerator laserWave(){
        while(true){
            yield return new WaitForSeconds( respawnTime);
            spanwProjetil();
        }
    }
}
