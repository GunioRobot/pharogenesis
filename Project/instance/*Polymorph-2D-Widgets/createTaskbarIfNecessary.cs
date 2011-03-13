createTaskbarIfNecessary
	"Private - create a new taskbar if not present."

	|w|
	w := self world.
	w taskbars ifEmpty: [
		TaskbarMorph new openInWorld: w.
		self moveCollapsedWindowsToTaskbar]