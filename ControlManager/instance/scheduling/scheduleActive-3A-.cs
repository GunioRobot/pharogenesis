scheduleActive: aController 
	"Make aController be scheduled as the active controller. Presumably the 
	active scheduling process asked to schedule this controller and that a 
	new process associated this controller takes control. So this is the last act 
	of the active scheduling process."
	<primitive: 19> "Simulation guard"
	self scheduleActiveNoTerminate: aController.
	Processor terminateActive