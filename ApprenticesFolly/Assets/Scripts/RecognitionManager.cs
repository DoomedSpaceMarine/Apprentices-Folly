using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RecognitionManager : MonoBehaviour
{
    EventManager eventManager;

    [SerializeField] private GameObject trianglePattern;

    public List<GameObject> shapeObjects;

    [SerializeField] private TrailRenderer trailRenderer;

    private bool dynamicMode = true;

    private void Awake()
    {
        eventManager = FindObjectOfType<EventManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetPatternShape("triangle");
            SetPatternPosition(dynamicMode);
        }
    }

    private void SetPatternShape(string pattern)
    {
        shapeObjects.Clear();
        eventManager.ResetScore();

        switch (pattern)
        {
            case "triangle":
                //Forms a list from the pattern child gameobjects
                foreach(Transform shape in trianglePattern.GetComponentInChildren<Transform>())
                {
                    shapeObjects.Add(shape.gameObject); 
                }
                //Send list size as the max score for the scoring system
                eventManager.GetMaxScore(shapeObjects.Count);
                //Sets objects on the shape list active
                for (int i = 0; i < shapeObjects.Count; i++)
                {
                    shapeObjects[i].gameObject.SetActive(true);
                }
                break;
        }
    }

    private void SetPatternPosition(bool dynamic)
    {
        if (dynamic)
        {
            trianglePattern.transform.position = Input.mousePosition;
        }
        else
        {
            return;
        }
        
    }

    private void ToggleDynamicMode(bool isDynamic)
    {
        dynamicMode = isDynamic;    
    }
}
