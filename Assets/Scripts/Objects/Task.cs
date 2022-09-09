using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Task", menuName ="Task")]
public class Task : ScriptableObject {

    public string taskName;
    public Item itemWanted;
    public float taskTime = 10f;

}
