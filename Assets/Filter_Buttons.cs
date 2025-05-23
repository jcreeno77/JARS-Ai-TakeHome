using UnityEngine;
using TMPro;

public class Filter_Buttons : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI AnimTypeText;

    public void FilterByCategory(string category)
    {
        AnimTypeText.text = category;
        if (category == "All")
        {
            // Show all buttons
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
            return;
        }
        else
        {
            foreach (Transform child in transform)
            {
                // Check if the button has the specified category
                string[] categories = child.GetComponent<Animation_MetaData>().categories;
                foreach (string cat in categories)
                {
                    if (cat == category)
                    {
                        child.gameObject.SetActive(true); // Show the button
                        break;
                    }
                    else
                    {
                        child.gameObject.SetActive(false); // Hide the button
                    }
                }
            }
        }
            
    }
}
