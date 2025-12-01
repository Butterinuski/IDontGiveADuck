using TMPro;
using UnityEngine;

public class SuccessText : MonoBehaviour
{
    public TMP_Text successText;

    public static SuccessText Instance { get; set; }


    private void Awake()
    {
        successText = GetComponent<TMP_Text>();

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void PointDisplay(int pointValue)
    {
        successText.text = $"+{pointValue}";
    }

}
