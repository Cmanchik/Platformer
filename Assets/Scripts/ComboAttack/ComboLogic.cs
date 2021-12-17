using UnityEngine;

namespace ComboAttack
{
    public class ComboLogic : MonoBehaviour
    {
        private float _damageMultiplier;

        private int _indexCombo;
        private float _lastAttackTime;
        private AnimatorStateInfo _stateInfo;

        [SerializeField] private Animator animator;

        [SerializeField] private ComboAttack[] comboAttacks;

        private void Awake()
        {
            _damageMultiplier = 1;
            animator = GetComponent<Animator>();

            foreach (ComboAttack combo in comboAttacks)
            {
                combo.LoadTimeAnimation();
                combo.ResetCombo();
            }
        }

        /// <summary>
        ///     Выполнение комбо атаки
        /// </summary>
        /// <param name="axis"></param>
        /// <returns>Название текущей анимации атаки</returns>
        public string CompleteCombo(string axis)
        {
            string nameTriggerAnimation = null;
            _damageMultiplier = 1;

            // поиск комбинации для продолжения
            foreach (ComboAttack combo in comboAttacks)
            {
                string comboBtn = combo.GetTriggerButton(_indexCombo);

                if (_indexCombo == combo.NumCombo && axis == comboBtn &&
                    HitTimeRange(Time.time, _lastAttackTime, combo.GetTimeAttack(_indexCombo - 1)))
                {
                    combo.NumCombo += 1;

                    if (nameTriggerAnimation != null) continue;

                    nameTriggerAnimation = combo.GetAnimationName(_indexCombo);
                    _lastAttackTime = Time.time;
                    _indexCombo++;
                }
                else
                {
                    combo.ResetCombo();
                }
            }

            // поиск новых комбинации для запуска с начала
            if (nameTriggerAnimation != null) return nameTriggerAnimation;

            _indexCombo = 0;
            foreach (ComboAttack combo in comboAttacks)
            {
                string comboBtn = combo.GetTriggerButton(_indexCombo);
                if (axis != comboBtn) continue;

                combo.NumCombo++;

                if (nameTriggerAnimation != null) continue;

                nameTriggerAnimation = combo.GetAnimationName(_indexCombo);
                _lastAttackTime = Time.time;
                _indexCombo++;
            }

            return nameTriggerAnimation;
        }

        private bool HitTimeRange(float currentTime, float lastTime, float? rangeTime)
        {
            if (rangeTime == null) return false;

            return currentTime - lastTime <= rangeTime;
        }

        public float GetCurrentDamageMultiplier()
        {
            _stateInfo = animator.GetCurrentAnimatorStateInfo(0);

            if (_stateInfo.IsTag("Attack"))
                foreach (ComboAttack combo in comboAttacks)
                    for (int i = 0; i < combo.MaxCombo; i++)
                    {
                        if (!_stateInfo.IsName(combo.GetAnimationName(i) + "_" + combo.name)) continue;
                        _damageMultiplier = combo.GetDamageMultiplier(i);
                        break;
                    }
            else
                _damageMultiplier = 1;

            return _damageMultiplier;
        }
    }
}