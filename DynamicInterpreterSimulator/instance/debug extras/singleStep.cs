singleStep
	| panic |
	Transcript endEntry.
	Sensor waitButton.
	panic _ Sensor blueButtonPressed.
	Sensor waitNoButton.
	panic ifTrue: [self error: 'single step aborted']