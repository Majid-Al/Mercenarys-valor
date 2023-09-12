using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mcscenemanager : MonoBehaviour
{
    [SerializeField]
    float distance = 1f;
    [SerializeField] private Camera cam;
    public GameObject bigHouse;
    public GameObject house;
    public GameObject shop;
    public GameObject shop2;
    public GameObject pit;

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
            if (Vector2.Distance(touchPosition, bigHouse.transform.position) < distance)
            {
                Debug.Log("bigHouse it is clicked");
            }
            else if (Vector2.Distance(touchPosition, house.transform.position) < distance)
            {
                Debug.Log("house is selected");
            }
            else if (Vector2.Distance(touchPosition, shop.transform.position) < distance)
            {
                Debug.Log("shop is selected");
            }
            else if (Vector2.Distance(touchPosition, shop2.transform.position) < distance)
            {
                Debug.Log("shop2 is selected");
            }
            else if (Vector2.Distance(touchPosition, pit.transform.position) < distance)
            {
                Debug.Log("pit is selected");
            }

        }
    }
}
