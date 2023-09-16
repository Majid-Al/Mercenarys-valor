using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class valueImageB : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI woodText;
    [SerializeField] private TextMeshProUGUI stoneText;
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI foodText;
    [SerializeField] private TextMeshProUGUI contractText;
    public int stone;
    public int gold;
    public int food;
   // Define the initial value of wood
    public int wood ;
    
   private void Start()
{
    UpdateText();
}

private void UpdateText()
{
    // Calculate the increase (30% more)
float increasePercentage = 0.30f; // 30% as a decimal
int increaseAmount = Mathf.RoundToInt(stone * increasePercentage);

// Add the increase to the original stone value
stone += increaseAmount;

    woodText.text = wood.ToString();
    stoneText.text = stone.ToString();
    goldText.text = gold.ToString();
    foodText.text = food.ToString();
}

private void OnMouseUp()
{
    UpdateText();
}

void Update()
{

}
 
}

