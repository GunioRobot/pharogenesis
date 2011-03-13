moveCollapsedWindowsToTaskbar
	"Move collapsed windows to the taskbar."
	
	(World systemWindows select: [:w | w isCollapsed]) do: [:w |
		w restore; minimize]