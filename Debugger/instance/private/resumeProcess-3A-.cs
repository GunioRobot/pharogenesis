resumeProcess: aScheduledController
	aScheduledController view erase.
	Smalltalk installLowSpaceWatcher.  "restart low space handler"
	interruptedProcess suspendedContext method
			== (Process compiledMethodAt: #terminate) ifFalse:
		[contextStackIndex > 1
			ifTrue: [interruptedProcess popTo: self selectedContext]
			ifFalse: [interruptedProcess install: self selectedContext].
		ScheduledControllers
						activeControllerNoTerminate: interruptedController
						andProcess: interruptedProcess].
	"if old process was terminated, just terminate current one"
	interruptedProcess _ nil. 
	aScheduledController closeAndUnscheduleNoErase.
	Processor terminateActive
