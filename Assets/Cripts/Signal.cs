using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Signal : MonoBehaviour
{
    public List<SignalListener> listener = new List<SignalListener>();

    public void raise()
    {
        for( int i = listener.Count -1; i >= 0; i--)
        {
            listener[i].OnSignalRaised();
        }
    }
}
