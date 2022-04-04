using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSettingsPanel : MonoBehaviour
{
    public GameObject SettingsPanel;

    public void OpenPanel()
    {
      if(SettingsPanel !=null)
        {
            bool isActive = SettingsPanel.activeSelf;
            SettingsPanel.SetActive(!isActive);
        }

    }
}
