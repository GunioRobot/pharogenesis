new
	"Creates a new Scheduler and make sure it gets initialized."

	| newScheduler |
	newScheduler _ self basicNew.
	newScheduler initialize.
	^ newScheduler.
