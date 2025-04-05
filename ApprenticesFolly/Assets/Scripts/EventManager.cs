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
    public event Action<float> onAddScore;
    public void AddScore(float addition) => onAddScore?.Invoke(addition);

    //Get Max Score Event
    public event Action<float> onGetMaxScore;
    public void GetMaxScore(float shapeListLenght) => onGetMaxScore?.Invoke(shapeListLenght);

    //Reset Score
    public event Action onResetScore;
    public void ResetScore() => onResetScore?.Invoke();

    //Set Spellcasting Zone
    public event Action<string> onSetSpellcastingZone;
    public void SetSpellcastingZone(string zone) => onSetSpellcastingZone?.Invoke(zone);

    //Add Wizard pages
    public event Action onAddToMaxPages;
    public void AddToMaxPages() => onAddToMaxPages?.Invoke();

    //Glyph drawn
    public event Action<string> onGlyphDrawn;
    public void GlyphDrawn(string glyph) => onGlyphDrawn?.Invoke(glyph);    

}
