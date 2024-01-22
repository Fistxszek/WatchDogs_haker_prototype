using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInWorldCanvas : MonoBehaviour
{
    [SerializeField] public GameObject ObjectToShow;

    public void ShowObject()
    {
        ObjectToShow.SetActive(true);
    }
    public void HideObject()
    {
        ObjectToShow.SetActive(false);
    }
}
