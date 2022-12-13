using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string SceneToLoad;
    public Vector2 playerPosition;
    public VectorValue playerStorage;

    public void OntriggerEnter2d(Collider2D other){
        if(other.CompareTag("Player") && !other.isTrigger){

            playerStorage.initialValue = playerPosition;
            SceneManager.LoadScene(SceneToLoad);
            
        }
    }

 
}