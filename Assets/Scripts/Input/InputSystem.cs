using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    [SerializeField] private KeyCode smile;
    [SerializeField] private KeyCode attack;
    [SerializeField] private KeyCode guard;
    List<IInputListener> listeners = new List<IInputListener>();


    public void Register(IInputListener listener)
    {
        if(!listeners.Contains(listener))
        {
            listeners.Add(listener);
        }
    }

    private void OnInput(KeyEvent keyEvent)
    {
        foreach (var listener in listeners)
        {
            listener.OnInput(keyEvent);
        }
    }

    private void Update() {
        if (Input.GetKeyDown(smile)) {
            OnInput(new KeyEvent(smile, InputEventName.Happy));}
        if (Input.GetKeyDown(attack)) {
            OnInput(new KeyEvent(attack,InputEventName.Attack));
        }
        if (Input.GetKeyDown(guard)) {
            OnInput(new KeyEvent(guard, InputEventName.Guard));
        }
    }



}
