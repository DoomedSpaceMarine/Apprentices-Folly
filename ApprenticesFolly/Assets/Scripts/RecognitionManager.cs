using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RecognitionManager : MonoBehaviour
{
    [SerializeField] private GameObject trianglePattern;

    public List<GameObject> shapeObjects;

    [SerializeField] private TrailRenderer trailRenderer;

    Ray ray;
    RaycastHit hit; 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetPatternShape("triangle");
            SetPatternPosition();
        }

        if (trailRenderer.emitting)
        {
            
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
                for (int i = 0; i < shapeObjects.Count; i++)
                {
                    shapeObjects[i].gameObject.SetActive(true);
                }
                break;
        }
    }

    private void SetPatternPosition()
    {
        trianglePattern.transform.position = Input.mousePosition;
    }
}
