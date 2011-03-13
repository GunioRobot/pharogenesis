open
	"Create an area on the screen in which the receiver's scheduled view can 
	be displayed. Make it the active view."

	view resizeInitially.
	status _ #open.
	ScheduledControllers scheduleActive: self