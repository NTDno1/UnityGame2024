using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Text13 : MonoBehaviour
{
    public TextMeshProUGUI uiText;
    public Movement movement;
    [SerializeField] GameObject gameobject;
    void Start()
    {
        movement = gameobject.GetComponent<Movement>();
        if (uiText != null)
        {
            uiText.text = "Nguyễn Văn A, Điểm: " + movement.diem;
        }
    }
    void Update()
    {
        uiText.text = "Nguyễn Văn A, Điểm: " + movement.diem;
    }
}
