using UnityEngine;
using System.Collections;

public class ConsoleToggler : MonoBehaviour {
    private bool consoleEnabled = false;
	private bool shiftDown = false;
    public ConsoleAction ConsoleOpenAction;
    public ConsoleAction ConsoleCloseAction;

    void Update ()
    {
        if (!Application.isEditor) return;
		if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) {
			shiftDown = true;
		}
		if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift)) {
			shiftDown = false;
		}
		if ((shiftDown || consoleEnabled) && Input.GetKeyDown(KeyCode.BackQuote)) {
            ToggleConsole();
        }
    }

    private void ToggleConsole() {
        consoleEnabled = !consoleEnabled;
        if (consoleEnabled) {
            ConsoleOpenAction.Activate();
        } else {
            ConsoleCloseAction.Activate();
        }
    }
}
