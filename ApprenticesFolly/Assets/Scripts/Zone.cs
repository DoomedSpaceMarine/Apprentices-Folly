using UnityEngine;

public class Zone : MonoBehaviour
{
    EventManager eventManager;

    [SerializeField] private string zoneText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        eventManager = FindObjectOfType<EventManager>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")) 
        {
            eventManager.SetSpellcastingZone(zoneText);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            eventManager.SetSpellcastingZone("");
        }
    }
}
