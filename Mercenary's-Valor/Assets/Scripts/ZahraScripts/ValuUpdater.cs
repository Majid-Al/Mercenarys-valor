using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ValueUpdater : MonoBehaviour

{
    [SerializeField] private TextMeshProUGUI woodText;
    [SerializeField] private TextMeshProUGUI stoneText;
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI foodText;

    public int stone;
    public int gold;
    public int food;
    public int wood;

    private void Start()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        // Calculate the increase (30% more)
        float increasePercentage = 0.30f; // 30% as a decimal

        // Determine which resource needs the increase based on the script's variable names
        int increaseAmount = 0;
        if (gameObject.name.Contains("ImageA"))
        {
            increaseAmount = Mathf.RoundToInt(wood * increasePercentage);
            wood += increaseAmount;
        }
        else if (gameObject.name.Contains("ImageB"))
        {
            increaseAmount = Mathf.RoundToInt(stone * increasePercentage);
            stone += increaseAmount;
        }
        else if (gameObject.name.Contains("ImageC"))
        {
            increaseAmount = Mathf.RoundToInt(gold * increasePercentage);
            gold += increaseAmount;
        }

        // Update the UI text fields
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
        // Other update logic can be added here if needed
    }
}
