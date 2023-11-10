using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mcscenemanager : MonoBehaviour
{
    [SerializeField]
    float distance = 1f;
    [SerializeField] private Camera cam;


    [Header("GameObject")]
    public GameObject bigHouse;
    public GameObject house;
    public GameObject management;
    public GameObject shop;
    public GameObject shop2;
    public GameObject pit;

    [Header("Panels")]
    public GameObject panelBigHouse;
    public GameObject panelHouse;
    public GameObject panelShop;
    public GameObject panelShop2;
    public GameObject panelPit;

    [Header("Boolean")]
    private bool bigHouseVisible = true;
    private bool houseVisible = true;
    private bool shopVisible = true;
    private bool shop2Visible = true;
    private bool pitVisible = true;

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

            if (bigHouse.activeSelf && Vector2.Distance(touchPosition, bigHouse.transform.position) < distance)
            {
                Debug.Log("bigHouse it is clicked");
                HandlebigHouse();

            }
            else if (bigHouse.activeSelf && Vector2.Distance(touchPosition, house.transform.position) < distance)
            {
                Debug.Log("house is selected");
                Handlehouse();
            }
            else if (bigHouse.activeSelf && Vector2.Distance(touchPosition, shop.transform.position) < distance)
            {
                Debug.Log("shop is selected");
                Handleshop();
            }

            else if (bigHouse.activeSelf && Vector2.Distance(touchPosition, shop2.transform.position) < distance)
            {
                Debug.Log("shop2 is selected");
                Handleshop2();
            }
            else if (bigHouse.activeSelf && Vector2.Distance(touchPosition, pit.transform.position) < distance)
            {
                Debug.Log("pit is selected");
                Handlepit();
            }

        }
    }

    void HandlebigHouse()
    {
        panelBigHouse.SetActive(true);

        bigHouseVisible = !bigHouseVisible;

        if (!bigHouseVisible)
        {
            bigHouse.SetActive(false);
            house.SetActive(false);
            shop.SetActive(false);
            shop2.SetActive(false);
            pit.SetActive(false);

        }
    }
    void Handlehouse()
    {
        panelHouse.SetActive(true);

        houseVisible = !houseVisible;

        if (!houseVisible)
        {
            bigHouse.SetActive(false);
            house.SetActive(false);
            shop.SetActive(false);
            shop2.SetActive(false);
            pit.SetActive(false);

        }
    }
    void Handleshop()
    {
        panelShop.SetActive(true);

        shopVisible = !shopVisible;

        if (!shopVisible)
        {
            bigHouse.SetActive(false);
            house.SetActive(false);
            shop.SetActive(false);
            shop2.SetActive(false);
            pit.SetActive(false);

        }
    }
    void Handleshop2()
    {
        panelShop2.SetActive(true);

        shop2Visible = !shop2Visible;

        if (!shop2Visible)
        {
            bigHouse.SetActive(false);
            house.SetActive(false);
            shop.SetActive(false);
            shop2.SetActive(false);
            pit.SetActive(false);

        }
    }
    void Handlepit()
    {
        panelPit.SetActive(true);

        pitVisible = !pitVisible;

        if (!pitVisible)
        {
            bigHouse.SetActive(false);
            house.SetActive(false);
            shop.SetActive(false);
            shop2.SetActive(false);
            pit.SetActive(false);

        }
    }
    public void DeclineAction()
    {
        if (!bigHouseVisible)
        {
            bigHouse.SetActive(true);
            house.SetActive(true);
            shop.SetActive(true);
            shop2.SetActive(true);
            pit.SetActive(true);

            bigHouseVisible = true;


        }
        else if (!houseVisible)
        {
            bigHouse.SetActive(true);
            house.SetActive(true);
            shop.SetActive(true);
            shop2.SetActive(true);
            pit.SetActive(true);

            houseVisible = true;

        }
        if (!shopVisible)
        {
            bigHouse.SetActive(true);
            house.SetActive(true);
            shop.SetActive(true);
            shop2.SetActive(true);
            pit.SetActive(true);


            shopVisible = true;

        }
        if (shop2Visible)
        {
            bigHouse.SetActive(true);
            house.SetActive(true);
            shop.SetActive(true);
            shop2.SetActive(true);
            pit.SetActive(true);

            shop2Visible = true;
        }

        if (pitVisible)
        {
            bigHouse.SetActive(true);
            house.SetActive(true);
            shop.SetActive(true);
            shop2.SetActive(true);
            pit.SetActive(true);


            pitVisible = true;
        }
    }
}


