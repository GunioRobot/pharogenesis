resumeProcess: aTopView

	Smalltalk isMorphic ifFalse: [aTopView erase].
	savedCursor ifNotNil: [Sensor currentCursor: savedCursor].
	isolationHead ifNotNil:
		[failedProject enterForEmergencyRecovery.
		isolationHead invoke. isolationHead _ nil].
	interruptedProcess suspendedContext method
			== (Process compiledMethodAt: #terminate)
		ifFalse:
		[contextStackIndex > 1
			ifTrue: [interruptedProcess popTo: self selectedContext]
			ifFalse: [interruptedProcess install: self selectedContext].
		Smalltalk isMorphic
			ifTrue: [Project current resumeProcess: interruptedProcess]
			ifFalse: [ScheduledControllers
						activeControllerNoTerminate: interruptedController
						andProcess: interruptedProcess]].

	"if old process was terminated, just terminate current one"
	interruptedProcess _ nil. "Before delete, so release doesn't terminate it"
	Smalltalk isMorphic
		ifTrue: [aTopView delete. World displayWorld]
		ifFalse: [aTopView controller closeAndUnscheduleNoErase].
	Smalltalk installLowSpaceWatcher.  "restart low space handler"
	Processor terminateActive
