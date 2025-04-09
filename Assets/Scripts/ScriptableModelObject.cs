using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/AstroModel")]

public class ScriptableModelObject : ScriptableObject
{
    public bool stateAvailable;
    public int amountToUnlock;
    public string starName;
    public string description;
    public GameObject model;
}
