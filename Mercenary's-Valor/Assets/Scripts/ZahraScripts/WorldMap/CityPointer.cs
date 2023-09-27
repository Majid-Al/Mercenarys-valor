using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CityPointer : MonoBehaviour

{
    [SerializeField]
    float distance = 1f;
    [SerializeField] private Camera cam;
    public GameObject ChildA;
    public GameObject ChildB;
    public GameObject ChildC;
    public GameObject ChildD;
    public GameObject ChildE;
    public GameObject panel;
    [SerializeField] private TextMeshProUGUI woodText;
    [SerializeField] private TextMeshProUGUI stoneText;
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI foodText;
    [SerializeField] private TextMeshProUGUI contractText;
    private GameObject activeChild; // Track the currently active child

    public int stone = 10;
    public int gold = 10;
    public int food = 10;
    public int wood = 10;
    public float increasePercentage = 0.30f; // 30% as a decimal 
    public bool ChildaA;
    public bool ChildaB;
    public bool ChildaC;
    public bool ChildaD;
    public bool ChildaE;
    bool childcheck = true;



    private int originalWood = 10; // Store the original wood value
    private int originalfood = 10; // Store the original wood value
    private int originalgold = 10; // Store the original wood value
    private int originalstone = 10; // Store the original wood value


    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = GetComponent<Camera>().ScreenToWorldPoint(touch.position);

            // Check if either object is close enough to the touch position and is active
            if (ChildA.activeSelf && Vector2.Distance(touchPosition, ChildA.transform.position) < distance)
            {
                HandleChildA();
            }
            else if (ChildB.activeSelf && Vector2.Distance(touchPosition, ChildB.transform.position) < distance)
            {
                HandleChildB();
            }
            // else if (ChildC.activeSelf && Vector2.Distance(touchPosition, ChildC.transform.position) < distance)
            // {
            //     UpdateUI();
            // }
            // else if (ChildD.activeSelf && Vector2.Distance(touchPosition, ChildD.transform.position) < distance)
            // {
            //     UpdateUI();
            // }
            // else if (ChildE.activeSelf && Vector2.Distance(touchPosition, ChildE.transform.position) < distance)
            // {
            //     UpdateUI();
            // }
        }
    }


    void HandleChildA()
    {
        panel.SetActive(true);

        // Reset the wood value to the original value (10)
        wood = originalWood;

        // Calculate the increase based on the original value (10)
        int increaseAmount = Mathf.RoundToInt(originalWood * increasePercentage);
        wood += increaseAmount;

        UpdateUI();
        ChildA.SetActive(false);

        bool ChildaA = true;
    }


    void HandleChildB()
    {
        panel.SetActive(true);

        // Reset the wood value to the original value (10)
        stone = originalstone;

        // Calculate the increase based on the original value (10)
        int increaseAmount = Mathf.RoundToInt(originalstone * increasePercentage);
        stone += increaseAmount;

        UpdateUI();
        ChildB.SetActive(false);

        // bool ChildaB = true;
    }





    void UpdateUI()
    {
        panel.SetActive(true);
        // Update the UI text fields
        woodText.text = wood.ToString();
        stoneText.text = stone.ToString();
        goldText.text = gold.ToString();
        foodText.text = food.ToString();
    }

    public void DeclineAction()
    {
        if (ChildaA == false)
        {
            ChildA.SetActive(true);
        }
        else if (ChildaB == false)
        {
            ChildA.SetActive(true);
        }

    }

}
