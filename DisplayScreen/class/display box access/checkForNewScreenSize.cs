checkForNewScreenSize
	Display extent = DisplayScreen actualScreenSize ifTrue: [^ self].
	DisplayScreen startUp.
	Smalltalk isMorphic
		ifTrue: [World restoreDisplay]
		ifFalse: [ScheduledControllers restore; searchForActiveController]