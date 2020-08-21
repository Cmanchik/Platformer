using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "New ComboAttack", menuName = "Combo Attack Data")]
public class ComboAttack : ScriptableObject
{
    [SerializeField]
    protected string[] _animationTriggerNames;

    [SerializeField]
    protected KeyCode[] _triggerButtons;

    [SerializeField]
    protected float[] _timeBtwAttacks;

    protected int _numCombo = 1;
    public int NumCombo 
    { 
        get { return _numCombo; } 
        set
        {
            if (value > MaxCombo)
                _numCombo = 1;
        }
    }

    public int MaxCombo { get { return _animationTriggerNames.Length; } }

    public float? GetTimeAttack(int index)
    {
        if (index >= _timeBtwAttacks.Length) return null;
        return _timeBtwAttacks[index];
    }

    public KeyCode? GetTriggerButton(int index)
    {
        if (index >= _triggerButtons.Length) return null;
        return _triggerButtons[index];
    }

    public string GetAnimationName(int index)
    {
        if (index >= _animationTriggerNames.Length) return null;
        return _animationTriggerNames[index];
    }

    public void ResetCombo()
    {
        _numCombo = 1;
    }
}
