resumeProcess: aTopView
	World ifNil: [aTopView erase].
	Smalltalk installLowSpaceWatcher.  "restart low space handler"
	interruptedProcess suspendedContext method
			== (Process compiledMethodAt: #terminate) ifFalse:
		[contextStackIndex > 1
			ifTrue: [interruptedProcess popTo: self selectedContext]
			ifFalse: [interruptedProcess install: self selectedContext].
		World ifNil: [ScheduledControllers
						activeControllerNoTerminate: interruptedController
						andProcess: interruptedProcess]
			ifNotNil: [interruptedProcess resume]].
	"if old process was terminated, just terminate current one"
	interruptedProcess _ nil. 
	World ifNil: [aTopView controller closeAndUnscheduleNoErase]
		ifNotNil: [aTopView delete].
	Processor terminateActive
