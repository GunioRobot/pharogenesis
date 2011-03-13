checkForNewScreenSize
	Display extent = DisplayScreen actualScreenSize ifTrue: [^ self].
	DisplayScreen startUp.
	Smalltalk isMorphic
		ifTrue: [Display restoreMorphicDisplay]
		ifFalse: [ScheduledControllers restore; searchForActiveController]