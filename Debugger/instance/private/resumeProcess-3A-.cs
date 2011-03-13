resumeProcess: aTopView 
	savedCursor
		ifNotNil: [Sensor currentCursor: savedCursor].
	isolationHead
		ifNotNil: [failedProject enterForEmergencyRecovery.
			isolationHead invoke.
			isolationHead := nil].
	interruptedProcess isTerminated
		ifFalse: [errorWasInUIProcess
				ifTrue: [Project resumeProcess: interruptedProcess]
				ifFalse: [interruptedProcess resume]].
	"if old process was terminated, just terminate current one"
	interruptedProcess := nil.
	"Before delete, so release doesn't terminate it"
	aTopView delete.
	World displayWorld.
	Smalltalk installLowSpaceWatcher.
	"restart low space handler"
	errorWasInUIProcess == false
		ifFalse: [Processor terminateActive]