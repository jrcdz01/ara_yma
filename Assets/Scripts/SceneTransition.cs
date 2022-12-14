using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string SceneToLoad;
    public Vector2 playerPosition;
    public VectorValue playerStorage;

    public void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player") && !other.isTrigger){
            // Debug.Log("Jogador entrou na área de colisao");
            playerStorage.initialValue = playerPosition;
            SceneManager.LoadScene(SceneToLoad);

            
        }
    }

 
}