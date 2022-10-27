using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable] //allows to change the attributes in the inspector 

public class Dialogue
{
	public string name;

	[TextArea(3, 10)]
	public string[] sentences;
}
