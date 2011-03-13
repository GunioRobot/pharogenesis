searchForActiveController
	"Find a scheduled controller that wants control and give control to it. If 
	none wants control, then see if the System Menu has been requested."
	| aController |
	activeController _ nil.
	activeControllerProcess _ Processor activeProcess.
	self activeController: self nextActiveController.
	Processor terminateActive