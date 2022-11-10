using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AttackBar : MonoBehaviour
{

	public Slider slider;
	public Gradient gradient;
	public Image fill;
	public int MaxAttack;
	//public TextMeshProUGUI ValueText;


	public void SetBaseAttack(int a)
	{
		slider.maxValue = MaxAttack;
		slider.value = a;
		fill.color = gradient.Evaluate(1f);
		//ValueText.text = slider.value.ToString();
	}

	public void SetAttack(int a)
	{
		slider.value = a;
		//ValueText.text = slider.value.ToString();

		fill.color = gradient.Evaluate(slider.normalizedValue);
	}

}
