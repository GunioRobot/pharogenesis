resumeProcess: aTopView 
	Smalltalk isMorphic
		ifFalse: [aTopView erase].
	savedCursor
		ifNotNil: [Sensor currentCursor: savedCursor].
	isolationHead
		ifNotNil: [failedProject enterForEmergencyRecovery.
			isolationHead invoke.
			isolationHead _ nil].
	interruptedProcess isTerminated ifFalse: [
		Smalltalk isMorphic
			ifTrue: [errorWasInUIProcess
					ifTrue: [Project resumeProcess: interruptedProcess]
					ifFalse: [interruptedProcess resume]]
			ifFalse: [ScheduledControllers activeControllerNoTerminate: interruptedController andProcess: interruptedProcess]].
	"if old process was terminated, just terminate current one"
	interruptedProcess _ nil.
	"Before delete, so release doesn't terminate it"
	Smalltalk isMorphic
		ifTrue: [aTopView delete.
			World displayWorld]
		ifFalse: [aTopView controller closeAndUnscheduleNoErase].
	Smalltalk installLowSpaceWatcher.
	"restart low space handler"
	errorWasInUIProcess == false
		ifFalse: [Processor terminateActive]