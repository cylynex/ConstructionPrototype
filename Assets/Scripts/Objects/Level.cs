using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Level", menuName ="Level")]
public class Level : ScriptableObject {

    public string projectNumber;
    public int levelNumber;
    public WinCondition winCondition;
    public Task[] tasks;

}
