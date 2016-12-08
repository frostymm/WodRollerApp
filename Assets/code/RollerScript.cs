using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class RollerScript : MonoBehaviour {

	public InputField diceNumField;
	public Text successText;
	public Text rollText;

	public int m_AgainModifier = 1;
	public Toggle[] m_Toggles;
	public void Toggle(Toggle tog)
	{
		if(tog.isOn)
			m_AgainModifier = m_Toggles.ToList().IndexOf(tog) + 1;
	}

	public void RollDice()
	{
		int diceToRoll = 0;
		Int32.TryParse(diceNumField.text, out diceToRoll);

		if(diceToRoll < 1)
		{
			int number = UnityEngine.Random.Range(1, 11);
			rollText.text = number.ToString();

			if(number == 1)
				successText.text = "Dramatic Failure!";
			else if(number == 10)
				successText.text = "Success!";
			else
				successText.text = "Failure.";
		}
		else
		{
			int numOfSuccess = 0;
			string rolls = "";

			int nextPool = diceToRoll;
			while(nextPool > 0)
			{
				diceToRoll = nextPool;
				nextPool = 0;
				while(diceToRoll > 0)
				{
					int number = UnityEngine.Random.Range(1, 11);
					rolls += number + ", ";

					//Add agains back into number of rolls
					if(number >= 8)
					{
						numOfSuccess++;
						if(number > 10 - m_AgainModifier)
						{
							nextPool++;
						}
					}
					
					diceToRoll--;
				}

				rolls += "\n";
			}

			successText.text = numOfSuccess + " Successes!";
			rollText.text = rolls;
		}

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
