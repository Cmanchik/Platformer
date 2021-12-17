using UnityEngine;

namespace ComboAttack
{
    [CreateAssetMenu(fileName = "New ComboAttack", menuName = "Combo Attack Data")]
    public class ComboAttack : ScriptableObject
    {
        private int _numCombo;

        private float[] _timeBtwAttacks;

        [SerializeField] protected string[] animationNames;

        [SerializeField] protected string[] triggerAxis;

        [SerializeField] protected float[] сomboDamageMultipliers;

        public int NumCombo
        {
            get => _numCombo;
            set
            {
                _numCombo = value;

                if (value >= MaxCombo)
                    _numCombo = 0;
            }
        }

        public int MaxCombo => animationNames.Length;

        public void LoadTimeAnimation()
        {
            _timeBtwAttacks = new float[animationNames.Length];
            for (int i = 0; i < animationNames.Length; i++)
                _timeBtwAttacks[i] = ((AnimationClip) Resources.Load("Attack Animations/" + animationNames[i])).length;
        }

        public float? GetTimeAttack(int index)
        {
            if (index >= _timeBtwAttacks.Length || index < 0) return null;
            return _timeBtwAttacks[index];
        }

        public string GetTriggerButton(int index)
        {
            if (index >= triggerAxis.Length || index < 0) return null;
            return triggerAxis[index];
        }

        public string GetAnimationName(int index)
        {
            if (index >= animationNames.Length || index < 0) return null;
            return animationNames[index];
        }

        public float GetDamageMultiplier(int index)
        {
            if (index >= сomboDamageMultipliers.Length || index < 0) return 1;
            return сomboDamageMultipliers[index];
        }

        public void ResetCombo()
        {
            _numCombo = 0;
        }
    }
}