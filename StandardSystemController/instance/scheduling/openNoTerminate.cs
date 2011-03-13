openNoTerminate
	"Create an area in which the receiver's scheduled view can be displayed. 
	Make it the active view. Do not terminate the currently active process."

	view resizeInitially.
	status := #open.
	ScheduledControllers scheduleActiveNoTerminate: self