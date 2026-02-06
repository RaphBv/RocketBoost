using UnityEngine;
using UnityEngine.InputSystem;

public class QuitApplication : MonoBehaviour
{
    void Update()
    {
        if(Keyboard.current.pKey.isPressed)
        {
            Application.Quit();
        }
    }
}
