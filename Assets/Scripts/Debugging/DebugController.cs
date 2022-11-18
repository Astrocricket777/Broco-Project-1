using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DebugController : MonoBehaviour
{
    public bool ShowConsole;

    public GameObject PM;

    public string input;

    public static DebugCommand Kill_All;
    public static DebugCommand Rosebud;
    public static DebugCommand<float> Set_Speed;

    public List<object> CommandList;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            ShowConsole = !ShowConsole;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            OnReturn();
        }
    }

    public void OnReturn()
    {
        if (ShowConsole)
        {
            HandleInput();
            input = "";

            Debug.Log("nnmosd");
        }
    }

    private void Awake()
    {
        Debug.Log("balsack");

        Kill_All = new DebugCommand("Kill_All", "Testing Your Nutsack", "Kill_All", () =>
        {
            Debug.Log("Killing All Nutsacks");
        });

        Rosebud = new DebugCommand("Rosebud", "Testing Your Rosebud", "Rosebud", () =>
        {
            Debug.Log("Killing All Rosebuds");
        });

        Set_Speed = new DebugCommand<float>("Set_Speed", "Testing Your Speed", "Set_Speed <Speed>", (x) =>
        {
            if (PM.GetComponent<PlayerMovement>() != null)
            {
                PM.GetComponent<PlayerMovement>().Speed = x;
            }
        });

        CommandList = new List<object>
        {
            Kill_All,
            Rosebud,
            Set_Speed
        };
    }

    private void OnGUI()
    {
        if (!ShowConsole)
        {
            return;
        }

        float y = 0f;

        GUI.Box(new Rect(0, y, Screen.width, 30), "");
        GUI.backgroundColor = new Color(0, 0, 0, 0);

        input = GUI.TextField(new Rect(10f, y + 5f, Screen.width - 20f, 20f), input);
    }

    private void HandleInput()
    {
        string[] Properties = input.Split(' ');

        for (int i = 0; i < CommandList.Count; i++)
        {
            DebugCommandBase Commandbase = CommandList[i] as DebugCommandBase;

            if (input.Contains(Commandbase.CommandID))
            {
                if (CommandList[i] as DebugCommand != null)
                {
                    (CommandList[i] as DebugCommand).Invoke();
                }
                else if (CommandList[i] as DebugCommand<float> != null)
                {
                    (CommandList[i] as DebugCommand<float>).Invoke(float.Parse(Properties[i]));
                }
            }
        }
    }

}
