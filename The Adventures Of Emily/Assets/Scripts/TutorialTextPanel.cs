using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialTextPanel : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private TextMeshProUGUI text;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetText(string s)
    {
        text.text = s;
    }

    public void OpenPanel()
    {
        animator.SetBool("InsideQuestion", true);
    }

    public void ClosePanel()
    {
        animator.SetBool("InsideQuestion", false);
    }
}
