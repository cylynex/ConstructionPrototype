using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="WinCondition", menuName ="WinCondition")]
public class WinCondition : ScriptableObject {

    public string conditionName;
    public float timer;
    public int numberTickets;
    [TextArea(5, 10)] public string winDescription;


}
