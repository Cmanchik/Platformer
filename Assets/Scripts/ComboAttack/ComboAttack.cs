using UnityEngine;

namespace ComboAttack
{
    [CreateAssetMenu(fileName = "New ComboAttack", menuName = "Combo Attack Data")]
    public class ComboAttack : ScriptableObject
    {
        [SerializeField]
        protected string[] animationNames;

        [SerializeField]
        protected string[] triggerAxis;

        [SerializeField]
        protected float[] сomboDamageMultipliers;

        protected float[] timeBtwAttacks;

        protected int numCombo;
        public int NumCombo 
        { 
            get => numCombo;
            set
            {
                numCombo = value;

                if (value >= MaxCombo)
                    numCombo = 0;
            }
        }

        public int MaxCombo => animationNames.Length;

        public void LoadTimeAnimation()
        {
            timeBtwAttacks = new float[animationNames.Length];
            for (int i = 0; i < animationNames.Length; i++)
            {
                timeBtwAttacks[i] = ((AnimationClip) Resources.Load("Attack Animations/" + animationNames[i])).length;
            }
        }

        public float? GetTimeAttack(int index)
        {
            if (index >= timeBtwAttacks.Length || index < 0) return null;
            return timeBtwAttacks[index];
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
            numCombo = 0;
        }
    }
}
