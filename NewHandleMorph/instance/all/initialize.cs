initialize
	waitingForClickInside _ true.
	super initialize.
	Preferences noviceMode ifTrue: [self setBalloonText: 'stretch']