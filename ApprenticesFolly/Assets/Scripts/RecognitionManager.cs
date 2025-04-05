using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RecognitionManager : MonoBehaviour
{
    [SerializeField] private GameObject trianglePattern;

    public List<GameObject> shapeObjects;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            SetPatternShape("triangle");
            SetPatternPosition();
        }
    }

    private void SetPatternShape(string pattern)
    {
        shapeObjects.Clear();

        switch (pattern)
        {
            case "triangle":
                foreach(Transform shape in trianglePattern.GetComponentInChildren<Transform>())
                {
                    shapeObjects.Add(shape.gameObject); 
                }
                break;
        }
    }

    private void SetPatternPosition()
    {
        trianglePattern.transform.position = Input.mousePosition;
    }
}
