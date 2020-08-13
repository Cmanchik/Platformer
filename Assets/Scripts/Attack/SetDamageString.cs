using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetDamageString : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;

    [SerializeField]
    private float timeOccurrence;
    [SerializeField]
    private float timeBlackout;

    public void SetDamage(float damage)
    {
        _text.CrossFadeAlpha(1, timeOccurrence, false);
        _text.text = Convert.ToString(damage);
        _text.CrossFadeAlpha(0, timeBlackout, false);
    }
}
