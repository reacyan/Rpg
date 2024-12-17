using UnityEngine;
using System.Linq;

public class PlayerInput : MonoBehaviour
{
    InputSystem inputSystem;
    Vector2 axes;
    public bool Run => inputSystem.PlayerController.Run.IsPressed();
    public bool move => inputSystem.PlayerController.Move.ReadValue<Vector2>() != Vector2.zero;
    public Vector2 currentAxes => move ? (axes = inputSystem.PlayerController.Move.ReadValue<Vector2>()) : axes;


    void OnEnable()
    {
        inputSystem = new InputSystem();
    }

    private void OnDisable()
    {
        DisableAllInputs();
    }

    public void DisableAllInputs()
    {
        inputSystem.PlayerController.Disable();
    }

    public void EnablePlayerControllerInput()
    {
        inputSystem.PlayerController.Enable();

        Cursor.visible = false;

        Cursor.lockState = CursorLockMode.Locked;
    }
}

