using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string SceneToLoad;
    public Vector2 playerNextPosition;
    public VectorValue playerStorage;
    public GameObject fadeInPanel;
    public GameObject fadeOutPanel;
    public float fadeWait;

    private void Awake(){
        if (fadeInPanel != null){
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }
    }

    public void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player") && !other.isTrigger){
            
            playerStorage.initialValue = playerNextPosition;
            StartCoroutine(FadeCo());
            // SceneManager.LoadScene(SceneToLoad);
        }
    }

    public IEnumerator FadeCo(){
        if(fadeOutPanel != null )
            Instantiate(fadeOutPanel, Vector3.zero, Quaternion.identity);
        
        yield return new WaitForSeconds(fadeWait);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(SceneToLoad);
        
        while(!asyncOperation.isDone){
            yield return null;
        }
    }

 
}