using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    //Count Score Event
    public event Action onCountScore;
    public void CountScore() => onCountScore?.Invoke();

    //Add Score Event
    public event Action<int> onAddScore;
    public void AddScore(int addition) => onAddScore?.Invoke(addition);

    //Get Max Score Event
    public event Action<int> onGetMaxScore;
    public void GetMaxScore(int shapeListLenght) => onGetMaxScore?.Invoke(shapeListLenght); 
}
