using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampMono : MonoBehaviour
{
    public AbsCamp Camp { get;private set; }

    public void OnInit(AbsCamp _camp)
    {
        Camp = _camp;
    }

    private void OnMouseUpAsButton()
    {
        OnClick();
    }


    private void OnClick()
    {
        GameFacade.Instance.UISystem.CampInfoUI.ShowUIInfo(Camp);
    }
}
