saveState
	"Save the current state in me prior to leaving this project"

	changeSet _ ChangeSet current.
	thumbnail ifNotNil: [thumbnail hibernate].
	Smalltalk isMorphic
		ifTrue:
			[world _ World.
			world sleep.
			ActiveWorld _ ActiveHand _ ActiveEvent _ nil]
		ifFalse:
			[world _ ScheduledControllers.
			ScheduledControllers unCacheWindows].
	Sensor flushAllButDandDEvents. "Will be reinstalled by World>>install"
	transcript _ Transcript.
