checkForNewScreenSize
	"Check whether the screen size has changed and if so take appropriate actions"

	Display extent = DisplayScreen actualScreenSize ifTrue: [^ self].
	DisplayScreen startUp.
	Smalltalk isMorphic
		ifTrue:
			[World restoreMorphicDisplay.
			World repositionFlapsAfterScreenSizeChange]
		ifFalse:
			[ScheduledControllers restore; searchForActiveController]