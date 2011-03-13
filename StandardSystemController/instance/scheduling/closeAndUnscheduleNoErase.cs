closeAndUnscheduleNoErase
	"Remove the scheduled view from the collection of scheduled views. Set 
	its status to closed but do not erase."

	status := #closed.
	view release.
	ScheduledControllers unschedule: self