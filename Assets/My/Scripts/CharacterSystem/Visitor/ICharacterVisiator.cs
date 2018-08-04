using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterVisiator
{
    void OnInit();
    void VisitorEnemy(AbsEnemy absEnemy);
    void VisitorSoldier(AbsSoldier absSoldier);

}
