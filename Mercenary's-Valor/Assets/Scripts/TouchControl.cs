


// joystick - like without the UI
using UnityEngine;

public class TouchControl : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float threshold = 0.1f; // Add a threshold value

    private bool isMoving = false;
    private Vector2 movementDirection;
    private Vector2 joystickStartPosition;
    private Vector2 joystickCurrentPosition;
    private Vector2 joystickOffset; // Declare joystickOffset here

    [SerializeField] GameObject sceneManager;
    bool canHeroWalk;

    private void Update()
    {
        canHeroWalk = sceneManager.GetComponent<BattleSceneManager>().p_canHeroWalk;

        if (canHeroWalk)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        // Store the initial touch position as the joystick start position
                        joystickStartPosition = touch.position;
                        break;
                    case TouchPhase.Moved:
                    case TouchPhase.Stationary:
                        // Calculate the distance and direction between the current touch position and the joystick start position
                        joystickCurrentPosition = touch.position;
                        joystickOffset = joystickCurrentPosition - joystickStartPosition; // Remove the Vector2 declaration

                        // Calculate the movement direction based on the joystick offset
                        movementDirection = joystickOffset.normalized;

                        // Move the character based on the calculated movement direction
                        transform.Translate(movementDirection * moveSpeed * Time.deltaTime);
                        break;
                    case TouchPhase.Ended:
                    case TouchPhase.Canceled:
                        // Reset the movement direction and joystick positions
                        movementDirection = Vector2.zero;
                        joystickStartPosition = Vector2.zero;
                        joystickCurrentPosition = Vector2.zero;
                        break;
                }

                // Set isMoving based on whether the joystick offset exceeds a threshold value
                isMoving = joystickOffset.magnitude > threshold;
            }
            else
            {
                isMoving = false;
            }
        }
    }
}


