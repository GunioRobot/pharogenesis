closeAndUnscheduleNoTerminate
	"Erase the receiver's view and remove it from the collection of scheduled views, but do not terminate the current process."

	status _ #closed.
	view erase.
	view release.
	ScheduledControllers unschedule: self.
