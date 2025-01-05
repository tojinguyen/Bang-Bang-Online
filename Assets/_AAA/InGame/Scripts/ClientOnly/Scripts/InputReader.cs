using UnityEngine;

public class InputReader : MonoBehaviour
{
    private void Update()
    {
        UserInputDataHolder.UserInput.Movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}