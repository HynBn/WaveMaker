using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Attackable
{
    public void Attacked(int damage, bool isMagic, bool isRanged);
}
