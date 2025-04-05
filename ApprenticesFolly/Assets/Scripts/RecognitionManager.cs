using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RecognitionManager : MonoBehaviour
{
    EventManager eventManager;

    [SerializeField] private GameObject trianglePattern;

    public List<GameObject> shapeObjects;

    [SerializeField] private TrailRenderer trailRenderer;

    Ray ray;
    RaycastHit hit;

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
            SetPatternPosition();
        }
    }

    private void SetPatternShape(string pattern)
    {
        shapeObjects.Clear();

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

    private void SetPatternPosition()
    {
        trianglePattern.transform.position = Input.mousePosition;
    }
}
