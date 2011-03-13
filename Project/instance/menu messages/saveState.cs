saveState
	"Save the current state in me prior to leaving this project"

	changeSet _ Smalltalk changes.
	Smalltalk isMorphic
		ifTrue:
			[world _ Display bestGuessOfCurrentWorld.
			world sleep]
		ifFalse:
			[world _ ScheduledControllers.
			ScheduledControllers unCacheWindows].
	Sensor eventQueue: nil. "Will be reinstalled by World>>install"
	transcript _ Transcript.
