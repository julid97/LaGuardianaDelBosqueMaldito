using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using System.Collections;
public class UIKeys : MonoBehaviour
{
    public PlayerInventory playerinventory;

    public TextMeshProUGUI keysValue;
    // Update is called once per frame
    void Update()
    {   
        if (playerinventory.keys <= 4)
        {
            keysValue.text = playerinventory.keys.ToString();
        }

        if(playerinventory.keys >= 4)
        {
       
            StartCoroutine(CleanRoutine());
        }


    }
    private IEnumerator CleanRoutine()
    {
        yield return new WaitForSeconds(6f);

        keysValue.text = 0.ToString();
    }

}


