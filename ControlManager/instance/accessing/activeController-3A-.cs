activeController: aController 
	"Set aController to be the currently active controller. Give the user 
	control in it."
	<primitive: 19> "Simulation guard"
	activeController _ aController.
	(activeController == screenController)
		ifFalse: [self promote: activeController].
	activeControllerProcess _ 
			[activeController startUp.
			self searchForActiveController] newProcess.
	activeControllerProcess priority: Processor userSchedulingPriority.
	activeControllerProcess resume