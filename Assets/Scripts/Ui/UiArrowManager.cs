using TMPro;
using UnityEngine;

public class UiArrowManager : MonoBehaviour
{
    public PlayerInventory playerinventory;

    public TextMeshProUGUI arrowValue;


    // Update is called once per frame
    void Update()
    {
        arrowValue.text = playerinventory.arrows.ToString();
    }
}
