using UnityEngine;

public class RecognitionManager : MonoBehaviour
{
    [SerializeField] private GameObject trianglePattern;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            SetPatternPosition();
        }
    }

    private void SetPatternPosition()
    {
        trianglePattern.transform.position = Input.mousePosition;
        Debug.Log("Code runs");
    }
}
