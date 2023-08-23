using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITrigger
{
    void TriggerEnter(Collider other);
    void TriggerExit(Collider other);
    void TriggerStay(Collider other);
}
