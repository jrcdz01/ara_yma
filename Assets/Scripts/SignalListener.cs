using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class SignalListener : MonoBehaviour {

    public Signal signal;
    public UnityEvent signalEvent;
    public void OnsignalRaised(){
        signalEvent.Invoke();
    }

    private void OnEnable(){
        signal.RegisterLitener(this);
    }

    private void OnDisable(){
        signal.DeRegisterListener(this);
    }
}
