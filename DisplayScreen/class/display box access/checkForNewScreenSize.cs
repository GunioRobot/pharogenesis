checkForNewScreenSize
	"Check whether the screen size has changed and if so take appropriate
	actions "
	Display extent = DisplayScreen actualScreenSize ifTrue: [^ self].
	DisplayScreen startUp.
	World restoreMorphicDisplay.
	World repositionFlapsAfterScreenSizeChange