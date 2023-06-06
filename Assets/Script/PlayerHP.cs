using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{

    [SerializeField] int _pHP = 5;
    [SerializeField] Text _hpText = default;

    void Update()
    {
        _hpText.text = "écäÓÅF" + _pHP.ToString("000");
    }

    public void Damaged()
    {
        if(0 < _pHP)
        {
            _pHP--;
        }
    }
}
