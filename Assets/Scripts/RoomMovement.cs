using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMovement : MonoBehaviour {
    
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovemant cameraPrincipal;
    
    // Start is called before the first frame update
    void Start() {
        cameraPrincipal = Camera.main.GetComponent<CameraMovemant>();

    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player") && !other.isTrigger){
            cameraPrincipal.minPosition += cameraChange;
            cameraPrincipal.maxPosition += cameraChange;
            other.transform.position += playerChange;
        }
    }
}
