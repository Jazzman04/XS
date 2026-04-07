using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacterData", menuName = "RPG/Character Data")]
public class NewScriptableObjectScript : ScriptableObject
{
    [Header("Name")]
    public string name; //Character Name

    [Header("Base stats")]
    public int baseStrength, baseConstitution, baseWill, baseWit, baseSpeed, baseSkill, baseLuck; //Base skill levels for character

    [Header("Growth Rates")]
    [Tooltip("Percent chance for a stat to increase. 0.0f = 0%, 1.0f = 100%")]
    // Percent chance for a stat increase 1.0f = 100%, 0.5f = 50% etc.
    public float strengthGrowth;
    public float conGrowth;
    public float willGrowth;
    public float witGrowth;
    public float speedGrowth;
    public float skillGrowth;
    public float luckGrowth;
}
