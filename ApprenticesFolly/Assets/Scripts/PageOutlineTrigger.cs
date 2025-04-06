using UnityEngine;

public class PageOutlineTrigger : MonoBehaviour
{
   [SerializeField] private Outline pageOutline;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pageOutline.enabled = true;
        }
        
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pageOutline.enabled = false;
        }
    }
}
