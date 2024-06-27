using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] GameObject redLight;
    [SerializeField] GameObject yellowlight;
    [SerializeField] GameObject greenLight;


    private List<SurvivalScript> agentsInTrigger = new List<SurvivalScript>();
    private bool isRepairing = false;

    void Start()
    {
        redLight.SetActive(true);
        greenLight.SetActive(false);
        yellowlight.SetActive(false);
    }

    void Update()
    {
        if (!isRepairing && agentsInTrigger.Count > 0)
        {
            StartCoroutine(Repair(agentsInTrigger[0]));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Agent"))
        {
            SurvivalScript agent = other.GetComponent<SurvivalScript>();
            if (agent != null && !agentsInTrigger.Contains(agent))
            {
                agentsInTrigger.Add(agent);
                Debug.Log("Agent entered generator trigger zone");
                agent.StopMovement();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Agent"))
        {
            Debug.Log("Agent is in Generator Trigger Stay Zone");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Agent"))
        {
            SurvivalScript agent = other.GetComponent<SurvivalScript>();
            if (agent != null && agentsInTrigger.Contains(agent))
            {
                agentsInTrigger.Remove(agent);
                Debug.Log("Agent exited generator trigger zone");
                agent.ResumeMovement();
            }
        }
    }

    IEnumerator Repair(SurvivalScript agent)
    {
        isRepairing = true;
        redLight.SetActive(false);
        yellowlight.SetActive(true);
        Debug.Log("Repairing Generator");
        yield return new WaitForSeconds(30f);
        Debug.Log("Generator Repaired");
        yellowlight.SetActive(false);
        greenLight.SetActive(true);
        agent.ResumeMovement();
        agentsInTrigger.Remove(agent);
        isRepairing = false;
    }
}
