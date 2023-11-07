using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mcscenemanager : MonoBehaviour
{
    [SerializeField]
    float distance = 1f;
    [SerializeField] private Camera cam;
    public GameObject house;
    public GameObject management;
    public GameObject shop;
    public GameObject arena;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = GetComponent<Camera>().ScreenToWorldPoint(touch.position);

            // Check if either object is close enough to the touch position
            if (Vector2.Distance(touchPosition, house.transform.position) < distance)
            {
                Debug.Log("House it is clicked");
            }
            else if (Vector2.Distance(touchPosition, management.transform.position) < distance)
            {
                Debug.Log("management   is selected");
            }
            else if (Vector2.Distance(touchPosition, shop.transform.position) < distance)
            {
                Debug.Log("shop is selected");
            }
            else if (Vector2.Distance(touchPosition, arena.transform.position) < distance)
            {
                Debug.Log("arena is selected");
            }

        }
    }
}
