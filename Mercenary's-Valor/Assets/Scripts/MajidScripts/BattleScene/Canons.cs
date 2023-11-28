
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Canons : MonoBehaviour
{
    public GameObject cannon1;
    public GameObject cannon2;
    public GameObject sceneManager;
    bool canHeroWalk;
    [SerializeField] float distance = 2f;

    public LineRenderer lineRenderer;
    bool startTheAttack = true;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        lineRenderer.enabled = false;
    }

    void Update()
    {

        canHeroWalk = sceneManager.GetComponent<BattleSceneManager>().p_canHeroWalk;

        if (canHeroWalk == false && Input.touchCount > 0)
        {
            // starts the attack
            if (startTheAttack && Input.touchCount > 0)
            {
                // Thread.Sleep(3000);
                // cannon1.GetComponent<Shooting>().beginShooting = true;
                // cannon2.GetComponent<Shooting>().beginShooting = true;
                // startTheAttack = false;
                StartCoroutine(StartCannonAfterDelay());
            }

            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = cam.ScreenToWorldPoint(touch.position);

            // Check if either object is close enough to the touch position
            if (Vector2.Distance(touchPosition, cannon1.transform.position) < distance)
            {
                RotateObject(cannon1, touchPosition);
            }
            else if (Vector2.Distance(touchPosition, cannon2.transform.position) < distance)
            {
                RotateObject(cannon2, touchPosition);
            }

            // If there are more than one touch, loop through all touches
            if (Input.touchCount > 1)
            {
                foreach (Touch touch2 in Input.touches)
                {
                    if (touch2.fingerId != touch.fingerId)
                    {
                        Vector2 touch2Position = cam.ScreenToWorldPoint(touch2.position);

                        if (Vector2.Distance(touch2Position, cannon1.transform.position) < distance)
                        {
                            RotateObject(cannon1, touch2Position);
                        }
                        else if (Vector2.Distance(touch2Position, cannon2.transform.position) < distance)
                        {
                            RotateObject(cannon2, touch2Position);
                        }
                    }
                }
                
            }
            
        }
        if (Input.touchCount == 0)
        {
            lineRenderer.enabled = false;
        }
    }
    IEnumerator StartCannonAfterDelay()
    {
        yield return new WaitForSeconds(1.5f);
        cannon1.GetComponent<Shooting>().beginShooting = true;
        cannon2.GetComponent<Shooting>().beginShooting = true;
        startTheAttack = false;
    }

    // all thanks to ChatGPT!!
    private void RotateObject(GameObject obj, Vector2 touchPosition)
    {
        Vector2 direction = touchPosition - (Vector2)obj.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 180;

        obj.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // Change the line renderer's position by 180 degrees from the cannon's direction
        Vector2 lineDirection = (Vector2)obj.transform.position - touchPosition;
        float lineAngle = Mathf.Atan2(lineDirection.y, lineDirection.x) * Mathf.Rad2Deg;

        Vector2 endpoint = (Vector2)obj.transform.position + new Vector2(Mathf.Cos(lineAngle * Mathf.Deg2Rad), Mathf.Sin(lineAngle * Mathf.Deg2Rad)) * 10; // Change 10 to the desired length
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, obj.transform.position);
        lineRenderer.SetPosition(1, endpoint);
    }
}
















/*

        Vector3 vec = obj.transform.rotation.eulerAngles;
        Debug.Log(direction);
       // Vector3 vec2 = (vec.x,vec.y,vec.z);
        lineRenderer.SetPosition(0, obj.transform.position);
        lineRenderer.SetPosition(1, direction);
        //lineRenderer.SetPositions();

*/


// code for landscape view 

// using System.Collections;
// using System.Collections.Generic;
// using System.Threading;
// using UnityEngine;

// public class Canons : MonoBehaviour
// {
//     public GameObject cannon1;
//     public GameObject canoon2;
//     public GameObject sceneManager;
//     bool canHeroWalk;
//     [SerializeField] float distance;


//     bool startTheAttack = true;
//     private Camera cam;

//     void Start()
//     {
//         cam = Camera.main;
//     }

//     void Update()
//     {

//         canHeroWalk = sceneManager.GetComponent<BattleSceneManager>().canHeroWalk;

//         if (canHeroWalk == false && Input.touchCount > 0)
//         {
//             // starts the attack
//             if (startTheAttack && Input.touchCount > 0)
//             {
//                 Thread.Sleep(3000);
//                 cannon1.GetComponent<Shooting>().beginShooting = true;
//                 canoon2.GetComponent<Shooting>().beginShooting = true;
//                 startTheAttack = false;
//             }

//             Touch touch = Input.GetTouch(0);
//             Vector3 touchPosition = cam.ScreenToWorldPoint(touch.position);

//             // Check if either object is close enough to the touch position
//             if (Vector3.Distance(touchPosition, cannon1.transform.position) < distance)
//             {
//                 RotateObject(cannon1, touchPosition);
//             }
//             else if (Vector3.Distance(touchPosition, canoon2.transform.position) < distance)
//             {
//                 RotateObject(canoon2, touchPosition);
//             }

//             // If there are more than one touch, loop through all touches
//             if (Input.touchCount > 1)
//             {
//                 foreach (Touch touch2 in Input.touches)
//                 {
//                     if (touch2.fingerId != touch.fingerId)
//                     {
//                         Vector3 touch2Position = cam.ScreenToWorldPoint(touch2.position);

//                         if (Vector3.Distance(touch2Position, cannon1.transform.position) < distance)
//                         {
//                             RotateObject(cannon1, touch2Position);
//                         }
//                         else if (Vector3.Distance(touch2Position, canoon2.transform.position) < distance)
//                         {
//                             RotateObject(canoon2, touch2Position);
//                         }
//                     }
//                 }
//             }
//         }
//     }

//     private void RotateObject(GameObject obj, Vector3 touchPosition)
//     {
//         Vector3 direction = touchPosition - obj.transform.position;
//         float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 180;
//         obj.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

//     }

// }
