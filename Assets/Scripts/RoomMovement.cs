using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMovement : MonoBehaviour {
    
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovemant camera;
    
    // Start is called before the first frame update
    void Start() {
        camera = Camera.main.GetComponent<CameraMovemant>();

    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            camera.minPosition += cameraChange;
            camera.maxPosition += cameraChange;
            other.transform.position += playerChange;
        }
    }
}
