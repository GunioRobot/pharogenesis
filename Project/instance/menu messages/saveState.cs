saveState
	"Save the current state in me prior to leaving this project"

	changeSet _ Smalltalk changes.
	Smalltalk isMorphic
		ifTrue:
			[world _ World.
			world sleep]
		ifFalse:
			[world _ ScheduledControllers.
			ScheduledControllers unCacheWindows].
	transcript _ Transcript.
	activeProcess _ nil