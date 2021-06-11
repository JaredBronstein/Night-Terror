using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text Left, Right, Forward, Back;

    public void UIChange(string Rooms)
    {
        string[] AdjacentRooms = Rooms.Split(char.Parse(","));
        Left.text = AdjacentRooms[0];
        Right.text = AdjacentRooms[1];
        Forward.text = AdjacentRooms[2];
        Back.text = AdjacentRooms[3];
    }
}
