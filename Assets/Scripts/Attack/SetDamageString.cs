﻿using System;
using System.Globalization;
using TMPro;
using UnityEngine;

namespace Attack
{
    public class SetDamageString : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI text;

        [SerializeField]
        private float timeOccurrence;
        [SerializeField]
        private float timeBlackout;

        public void SetDamage(float damage)
        {
            text.CrossFadeAlpha(1, timeOccurrence, false);
            text.text = Convert.ToString(damage, CultureInfo.CurrentCulture);
            text.CrossFadeAlpha(0, timeBlackout, false);
        }
    }
}
