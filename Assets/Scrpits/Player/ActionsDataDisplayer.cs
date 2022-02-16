using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActionsDataDisplayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI movesCountText;
    [SerializeField] private TextMeshProUGUI successfalCountText;

    public void UpdateUi(int movesCount, int succesfallCount)
    {
        movesCountText.text = movesCount.ToString();
        successfalCountText.text = succesfallCount.ToString();
    }

}
