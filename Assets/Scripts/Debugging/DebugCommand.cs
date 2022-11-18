using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DebugCommandBase
{
    private string MCommandID;
    private string MCommandDescription;
    private string MCommandFormat;

    public string CommandID { get {return MCommandID; } }
    public string CommandDescription { get {return MCommandDescription; } }
    public string CommandFormat {get {return MCommandFormat; } }

    public DebugCommandBase(string ID, string Description, string Format)
    {
        MCommandID = ID;
        MCommandDescription = Description;
        MCommandFormat = Format;
    }
}

public class DebugCommand : DebugCommandBase
{
    private Action Command;

    public DebugCommand(string ID, string Description, string Format, Action Command) : base (ID, Description, Format)
    {
        this.Command = Command;
    }

    public void Invoke()
    {
        Command.Invoke();
    }
}

public class DebugCommand<T1> : DebugCommandBase
{
    private Action<T1> Command;

    public DebugCommand(string ID, string Description, string Format, Action<T1> Command) : base (ID, Description, Format)
    {
        this.Command = Command;
    }

    public void Invoke(T1 Value)
    {
        Command.Invoke(Value);
    }
}
