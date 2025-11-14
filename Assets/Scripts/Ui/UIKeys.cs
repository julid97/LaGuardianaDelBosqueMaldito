using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
public class UIKeys : MonoBehaviour
{
    public PlayerInventory playerinventory;

    public TextMeshProUGUI keysValue;
    // Update is called once per frame
    void Update()
    {
        keysValue.text = playerinventory.keys.ToString();
    }
}
