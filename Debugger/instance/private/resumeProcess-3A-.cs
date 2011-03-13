resumeProcess: aScheduledController
	aScheduledController view erase.
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
