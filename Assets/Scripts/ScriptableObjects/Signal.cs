using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Signal : ScriptableObject {
   
    public List<SignalListener> listeners = new List<SignalListener>();

    public void Raise(){
        for( int sinal=listeners.Count - 1; sinal >=0; sinal -- ){
            listeners[sinal].OnsignalRaised();
        }
    }

    public void RegisterLitener(SignalListener listener){
        listeners.Add(listener);
    }

    public void DeRegisterListener(SignalListener listener){
        listeners.Remove(listener);
    }
}
