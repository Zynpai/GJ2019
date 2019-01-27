using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePrefs : MonoBehaviour {

    public Dropdown dropdownMinutes;
    public Dropdown dropdownSeconds;
    public Dropdown dropdownSpawn;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdatePrefs()
    {
        //Text dropdownText = dropdownMinutes.GetComponent<Text>();
        int menuIndex1 = dropdownMinutes.value;
        List<Dropdown.OptionData> menuOptions1 = dropdownMinutes.options;
        string minutesVal = menuOptions1[menuIndex1].text;

        int menuIndex2 = dropdownSeconds.value;
        List<Dropdown.OptionData> menuOptions2 = dropdownSeconds.options;
        string secondsVal = menuOptions2[menuIndex2].text;

        int menuIndex3 = dropdownSpawn.value;
        List<Dropdown.OptionData> menuOptions3 = dropdownSpawn.options;
        string spawnVal = menuOptions3[menuIndex3].text;

        PlayerPrefs.SetInt("MinutesVal", int.Parse(minutesVal));
        PlayerPrefs.SetInt("SecondsVal", int.Parse(secondsVal));
        PlayerPrefs.SetInt("SpawnVal", int.Parse(spawnVal));
    }
}
