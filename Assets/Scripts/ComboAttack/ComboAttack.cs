using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New ComboAttack", menuName = "Combo Attack Data")]
public class ComboAttack : ScriptableObject
{
    [SerializeField]
    protected string[] _animationNames;

    [SerializeField]
    protected KeyCode[] _triggerButtons;

    [SerializeField]
    protected float[] _сomboDamageMultipliers;

    protected float[] _timeBtwAttacks;

    protected int _numCombo = 0;
    public int NumCombo 
    { 
        get { return _numCombo; } 
        set
        {
            _numCombo = value;

            if (value >= MaxCombo)
                _numCombo = 0;
        }
    }

    public int MaxCombo { get { return _animationNames.Length; } }

    public void LoadTimeAnimation()
    {
        _timeBtwAttacks = new float[_animationNames.Length];
        for (int i = 0; i < _animationNames.Length; i++)
        {
            _timeBtwAttacks[i] = (Resources.Load("Attack Animations/" + _animationNames[i]) as AnimationClip).length;
        }
    }

    public float? GetTimeAttack(int index)
    {
        if (index >= _timeBtwAttacks.Length || index < 0) return null;
        return _timeBtwAttacks[index];
    }

    public KeyCode? GetTriggerButton(int index)
    {
        if (index >= _triggerButtons.Length || index < 0) return null;
        return _triggerButtons[index];
    }

    public string GetAnimationName(int index)
    {
        if (index >= _animationNames.Length || index < 0) return null;
        return _animationNames[index];
    }

    public float GetDamageMultiplier(int index)
    {
        if (index >= _сomboDamageMultipliers.Length || index < 0) return 1;
        return _сomboDamageMultipliers[index];
    }

    public int GetIndexCombo(string name)
    {
        return Array.IndexOf(_animationNames, name);
    }

    public void ResetCombo()
    {
        _numCombo = 0;
    }
}
