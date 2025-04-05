using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RecognitionManager : MonoBehaviour
{
    EventManager eventManager;

    [SerializeField] private GameObject trianglePattern;
    [SerializeField] private GameObject mGlyphPattern;

    public List<GameObject> shapeObjects;

    [SerializeField] private TrailRenderer trailRenderer;

    public string zonePattern;

    private bool dynamicMode = true;

    private void OnEnable()
    {
        eventManager = FindObjectOfType<EventManager>();

        eventManager.onSetSpellcastingZone += SetSpellcastingZone;
    }

    private void OnDisable()
    {
        eventManager.onSetSpellcastingZone -= SetSpellcastingZone;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetPatternShape(zonePattern);
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
            case "m":
                //Forms a list from the pattern child gameobjects
                foreach (Transform shape in mGlyphPattern.GetComponentInChildren<Transform>())
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
            //When not in a zone
            case "":
                return;
                break;
        }
    }

    private void SetPatternPosition(bool dynamic)
    {
        if (dynamic)
        {
            trianglePattern.transform.position = Input.mousePosition;
            mGlyphPattern.transform.position = Input.mousePosition;
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

    private void SetSpellcastingZone(string zone)
    {
        zonePattern = zone; 

        
            switch (zonePattern)
            {
                case "triangle":
                    trianglePattern.SetActive(true);
                    break;
                case "m":
                    mGlyphPattern.SetActive(true);
                    break;
                case "":
                    trianglePattern.SetActive(false);
                    break;

            }
        
    }
}
