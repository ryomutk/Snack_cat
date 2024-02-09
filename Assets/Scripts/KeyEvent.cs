using UnityEngine;

public struct KeyEvent
{
    public KeyCode Key { get; }
    public InputEventName Name { get; }

    public KeyEvent(KeyCode key, InputEventName name)
    {
        Key = key;
        Name = name;
    }
}