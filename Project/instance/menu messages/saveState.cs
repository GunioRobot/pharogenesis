saveState
	"Save the current state in me prior to switching projects"

	world isMorph ifTrue: [world _ World]
				ifFalse: [world _ ScheduledControllers.
						ScheduledControllers unCacheWindows].
	changeSet _ Smalltalk changes.
	transcript _ Transcript.
	displayDepth _ Display depth.
