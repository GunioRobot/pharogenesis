initialize
"initialize the state of the receiver"

	super initialize.
""
	waitingForClickInside _ true.
	Preferences noviceMode
		ifTrue: [self setBalloonText: 'stretch']