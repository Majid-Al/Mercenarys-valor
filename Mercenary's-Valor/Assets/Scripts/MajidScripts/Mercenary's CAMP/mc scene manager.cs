using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mcscenemanager : MonoBehaviour
{
    [SerializeField]
    float distance = 1f;
    [SerializeField] private Camera cam;


    [Header("GameObject")]
    public GameObject Managment;
    public GameObject house;
    public GameObject shop;
    public GameObject area;

    [Header("Panels")]
    public GameObject panelManagment;
    public GameObject panelHouse;
    public GameObject panelShop;
    public GameObject panelarea;

    [Header("Boolean")]
    private bool ManagmentVisible = true;
    private bool houseVisible = true;
    private bool shopVisible = true;
    private bool areaVisible = true;

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

            if (Managment.activeSelf && Vector2.Distance(touchPosition, Managment.transform.position) < distance)
            {
                Debug.Log("bigHouse it is clicked");
                HandleManagment();

            }
            else if (house.activeSelf && Vector2.Distance(touchPosition, house.transform.position) < distance)
            {
                Debug.Log("house is selected");
                Handlehouse();
            }
            else if (shop.activeSelf && Vector2.Distance(touchPosition, shop.transform.position) < distance)
            {
                Debug.Log("shop is selected");
                Handleshop();
            }

            else if (area.activeSelf && Vector2.Distance(touchPosition, area.transform.position) < distance)
            {
                Handlearea();
            }

        }
    }

    void HandleManagment()
    {
        panelManagment.SetActive(true);

       ManagmentVisible = !ManagmentVisible;

        if (!ManagmentVisible)
        {
            Managment.SetActive(false);
            house.SetActive(false);
            shop.SetActive(false);
           area.SetActive(false);

        }
    }
    void Handlehouse()
    {
        panelHouse.SetActive(true);

        houseVisible = !houseVisible;

        if (!houseVisible)
        {
            Managment.SetActive(false);
            house.SetActive(false);
            shop.SetActive(false);
           area.SetActive(false);

        }
    }
    void Handleshop()
    {
        panelShop.SetActive(true);

        shopVisible = !shopVisible;

        if (!shopVisible)
        {
            Managment.SetActive(false);
            house.SetActive(false);
            shop.SetActive(false);
           area.SetActive(false);

        }
    }
    
    void Handlearea()
    {
        panelarea.SetActive(true);

        areaVisible = !areaVisible;

        if (!areaVisible)
        {
            Managment.SetActive(false);
            house.SetActive(false);
            shop.SetActive(false);
            area.SetActive(false);

        }
    }
    public void DeclineAction()
    {
        if (!ManagmentVisible)
        {
           Managment.SetActive(true);
            house.SetActive(true);
            shop.SetActive(true);
            area.SetActive(true);

            ManagmentVisible = true;


        }
        else if (!houseVisible)
        {
           Managment.SetActive(true);
            house.SetActive(true);
            shop.SetActive(true);
            area.SetActive(true);

            houseVisible = true;

        }
        if (!shopVisible)
        {
           Managment.SetActive(true);
            house.SetActive(true);
            shop.SetActive(true);
            area.SetActive(true);


            shopVisible = true;

        }
        
        if (areaVisible)
        {
           Managment.SetActive(true);
            house.SetActive(true);
            shop.SetActive(true);
            area.SetActive(true);


            areaVisible = true;
        }
    }
}


