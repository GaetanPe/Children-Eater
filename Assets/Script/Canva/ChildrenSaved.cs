using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChildrenSaved : MonoBehaviour
{
    [SerializeField] private int childrenSaved = 0;
    public int childrenSavedCount = 0;
    public TextMeshProUGUI textChild;
    public GameObject victoryText;
    private void LateUpdate()
    {
        childrenSaved = childrenSavedCount;
        textChild.text = "Child saved: " + childrenSaved + "/3 ";
        if(childrenSaved == 3)
        {
            victoryText.SetActive(true);
        }
        else
        {
            victoryText.SetActive(false);
        }
    }
}
