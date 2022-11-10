using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DefenseBar : MonoBehaviour
{

	public Slider slider;
	public Gradient gradient;
	public Image fill;
	public int MaxDefense;
	public TextMeshProUGUI ValueText;


	public void SetBaseDefense(int d)
	{
		slider.maxValue = MaxDefense;
		slider.value = d;
		fill.color = gradient.Evaluate(1f);
		ValueText.text = slider.value.ToString();
	}

	public void SetDefense(int d)
	{
		slider.value = d;
		ValueText.text = slider.value.ToString();

		fill.color = gradient.Evaluate(slider.normalizedValue);
	}

}
