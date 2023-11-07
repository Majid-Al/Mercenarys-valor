using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CityPointer : MonoBehaviour

{
    [SerializeField] float distance = 1f;
    [SerializeField] private Camera cam;

    [Header("Childs")]
    public GameObject ChildA;
    public GameObject ChildB;
    public GameObject ChildC;
    public GameObject ChildD;
    // public GameObject ChildE;
    public GameObject panel;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI woodText;
    [SerializeField] private TextMeshProUGUI stoneText;
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI foodText;
    [SerializeField] private TextMeshProUGUI contractText;

    [Header("Text's value")]

    private int originalWood = 10; // Store the original wood value
    private int originalfood = 10; // Store the original wood value
    private int originalgold = 10; // Store the original wood value
    private int originalstone = 10; // Store the original wood value
    public float increasePercentage = 0.30f; // 30% as a decimal 

    [Header("Booleans")]
    private bool childAVisible = true;
    private bool childBVisible = true;
    private bool childCVisible = true;
    private bool childDVisible = true;
    // private bool childEVisible = true;



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
            else if (ChildC.activeSelf && Vector2.Distance(touchPosition, ChildC.transform.position) < distance)
            {
                HandleChildC();
            }
            else if (ChildD.activeSelf && Vector2.Distance(touchPosition, ChildD.transform.position) < distance)
            {
                HandleChildD();
            }
        
        }
    }


    void HandleChildA()
    {
        panel.SetActive(true);

        // Reset the value to the original value (10)
        GameManager.Instance.wood = originalWood;

        // Calculate the increase based on the original value (10)
        int increaseAmount = Mathf.RoundToInt(originalWood * increasePercentage);
         GameManager.Instance.wood += increaseAmount;


        UpdateUI();

        //disable the child when touched
        childAVisible = !childAVisible;

        if (!childAVisible)
        {
            ChildA.SetActive(false);
        }
    }


    void HandleChildB()
    {
        panel.SetActive(true);

        // Reset the  value to the original value (10)
       GameManager.Instance.stone = originalstone;

        // Calculate the increase based on the original value (10)
        int increaseAmount = Mathf.RoundToInt(originalstone * increasePercentage);
       GameManager.Instance.stone += increaseAmount;

        UpdateUI();

        childBVisible = !childBVisible;

        if (!childBVisible)
        {
            ChildB.SetActive(false);
        }

    }

    void HandleChildC()
    {
        panel.SetActive(true);

        // Reset the  value to the original value (10)
       GameManager.Instance.gold = originalgold;

        // Calculate the increase based on the original value (10)
        int increaseAmount = Mathf.RoundToInt(originalgold * increasePercentage);
        GameManager.Instance.gold += increaseAmount;

        UpdateUI();

        childCVisible = !childCVisible;

        if (!childCVisible)
        {
            ChildC.SetActive(false);
        }

    }


    void HandleChildD()
    {
        panel.SetActive(true);

        // Reset the  value to the original value (10)
        GameManager.Instance.food = originalfood;

        // Calculate the increase based on the original value (10)
        int increaseAmount = Mathf.RoundToInt(originalfood * increasePercentage);
        GameManager.Instance.food += increaseAmount;

        UpdateUI();

        childDVisible = !childDVisible;

        if (!childDVisible)
        {
            ChildD.SetActive(false);
        }

    }





    void UpdateUI()
    {
        // Update the UI text fields
        woodText.text = GameManager.Instance.wood.ToString();
        stoneText.text =GameManager.Instance.stone.ToString();
        goldText.text = GameManager.Instance.gold.ToString();
        foodText.text = GameManager.Instance.food.ToString();
    }

    public void DeclineAction()
    {
        // Check the visibility state of Child A and toggle it
        if (!childAVisible)
        {
            ChildA.SetActive(true);
        }

        // Check the visibility state of Child B and toggle it
        if (!childBVisible)
        {
            ChildB.SetActive(true);
        }

        // Check the visibility state of Child C and toggle it
        if (!childCVisible)
        {
            ChildC.SetActive(true);
        }

        // Check the visibility state of Child D and toggle it
        if (!childDVisible)
        {
            ChildD.SetActive(true);
        }

        

    }


}


