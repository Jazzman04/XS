using UnityEngine;

[CreateAssetMenu(fileName = "NewScriptableObjectScript", menuName = "Scriptable Objects/NewScriptableObjectScript")]
public class NewScriptableObjectScript : ScriptableObject
{
    public string name; //Character Name

    public int baseStrength, baseConstitution, baseWill, baseWit, baseSpeed, baseSkill, baseLuck; //Base skill levels for character

    [Header("Growth Rates")]
    // Percent chance for a stat increase 1.0f = 100%, 0.5f = 50% etc.
    public float strengthGrowth;
    public float conGrowth;
    public float willGrowth;
    public float witGrowth;
    public float speedGrowth;
    public float skillGrowth;
    public float luckGrowth;
}
