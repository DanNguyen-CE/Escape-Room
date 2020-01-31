using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Runtime.InteropServices;

public class Controller : MonoBehaviour {

	public RazerHydraPlugin hydra;
	public CharacterController controller;
	public GameObject myCamera;
	public float xSpeed_walk = 10.0f;
	public float ySpeed_walk = 10.0f;
	public float xSpeed_look = 2.0f;
	public float ySpeed_look = 2.0f;

	void Start()
	{
		hydra = new RazerHydraPlugin();
		hydra.init();

		CharacterController controller = GetComponent<CharacterController>();
	}

	void Update()
	{
		Cursor.lockState = CursorLockMode.Locked;

		// LEFT CONTROLLER
		hydra.getNewestData(0);

		controller.SimpleMove(transform.right * hydra.data.joystick_x * xSpeed_walk);
		controller.SimpleMove(transform.forward * hydra.data.joystick_y * ySpeed_walk);

		if (hydra.data.buttons == 128) // Left Bumper emulates a right mouse click.
			MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightDown);
		else
			MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.RightUp);

		//RIGHT CONTROLLER
		hydra.getNewestData(1);

		controller.transform.Rotate(0, hydra.data.joystick_x * xSpeed_look, 0);
		myCamera.transform.Rotate(-hydra.data.joystick_y * ySpeed_look, 0, 0);

		if (hydra.data.buttons == 128) // Right Bumper emulates a left mouse click.
			MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
		else
			MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
	}
}

// Used to emulate mouse click for Razer Hydra button press.
public class MouseOperations
{
    [Flags]
    public enum MouseEventFlags
    {
        LeftDown = 0x00000002,
        LeftUp = 0x00000004,
        MiddleDown = 0x00000020,
        MiddleUp = 0x00000040,
        Move = 0x00000001,
        Absolute = 0x00008000,
        RightDown = 0x00000008,
        RightUp = 0x00000010
    }

    [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool SetCursorPos(int x, int y);      

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool GetCursorPos(out MousePoint lpMousePoint);

    [DllImport("user32.dll")]
    private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

    public static void SetCursorPosition(int x, int y) 
    {
        SetCursorPos(x, y);
    }

    public static void SetCursorPosition(MousePoint point)
    {
        SetCursorPos(point.X, point.Y);
    }

    public static MousePoint GetCursorPosition()
    {
        MousePoint currentMousePoint;
        var gotPoint = GetCursorPos(out currentMousePoint);
        if (!gotPoint) { currentMousePoint = new MousePoint(0, 0); }
        return currentMousePoint;
    }

    public static void MouseEvent(MouseEventFlags value)
    {
        MousePoint position = GetCursorPosition();

        mouse_event
            ((int)value,
             position.X,
             position.Y,
             0,
             0)
            ;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MousePoint
    {
        public int X;
        public int Y;

        public MousePoint(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
