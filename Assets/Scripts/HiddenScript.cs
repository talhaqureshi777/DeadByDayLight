using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenScript : MonoBehaviour
{
    public bool isHidden;

    void Start()
    {
        isHidden = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player is in Hidden State");
            isHidden = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player is not in Hidden State");
            isHidden = false;
        }
    }
}
