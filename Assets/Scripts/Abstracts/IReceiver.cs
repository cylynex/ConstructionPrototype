using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IReceiver {
    
    public bool Receive(Item receivedItem, int amount, GameObject sender);

}
