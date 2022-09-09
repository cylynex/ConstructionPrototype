using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Project", menuName ="Project")]
public class Project : ScriptableObject {

    public string projectName;
    [TextArea(5, 10)] public string projectDescription;
    public List<Level> levels = new List<Level>();
    public string sceneName;

}