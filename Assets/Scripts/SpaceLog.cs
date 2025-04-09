using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SpaceLog : MonoBehaviour
{
    public TMP_Dropdown DropDownOption;
    public ScriptableModelObject[] astroModels;
    public TextMeshProUGUI selectedModelName;
    public TextMeshProUGUI selectedModelDescription;
    public TextMeshProUGUI messageError;
    public TextMeshProUGUI distanceTextScreen;
    public TextMeshProUGUI starsTextScreen;

    private int scoreDistancePlayer = 0;
    private int starsPlayer = 0;

    private GameObject actualDisplay;
    private readonly List<string> optionsModels = new List<string>();
    void Start()
    {
        GameObject clonModel = Instantiate(astroModels[0].model, new Vector3(0, 0.4f, 0), Quaternion.identity) as GameObject;
        selectedModelName.text = astroModels[0].starName;
        selectedModelDescription.text = astroModels[0].description;
        actualDisplay = clonModel;
        scoreDistancePlayer = PlayerPrefs.GetInt("DistanceCoveredPref");
        starsPlayer = PlayerPrefs.GetInt("StarsCollectedPref");

        distanceTextScreen.text = scoreDistancePlayer.ToString() + "m";
        starsTextScreen.text = starsPlayer.ToString() + " Stars";

        for (int i = 0; i < astroModels.Length; i++)
        {
            optionsModels.Add(astroModels[i].starName);
            if (scoreDistancePlayer >= astroModels[i].amountToUnlock)
            {
                astroModels[i].stateAvailable = true;
            }
        }

        DropDownOption.ClearOptions();
        DropDownOption.AddOptions(optionsModels);
    }

    public void OnChangeElement(int option)
    {
        if (astroModels[option].stateAvailable)
        {
            Destroy(actualDisplay);
            GameObject clonModel = Instantiate(astroModels[option].model, new Vector3(0, 0.4f, 0), Quaternion.identity) as GameObject;
            selectedModelName.text = astroModels[option].starName;
            selectedModelDescription.text = astroModels[option].description;
            actualDisplay = clonModel;
        } else
        {
            StartCoroutine(DisplayMessageScore());
            messageError.text = "You need at least " + astroModels[option].amountToUnlock.ToString() + " points to unlock this";
        }
    }

    IEnumerator DisplayMessageScore()
    {
        yield return new WaitForSeconds(2);
        messageError.text = "";
        StopCoroutine(DisplayMessageScore());
    }
    
}
