aliceExampleFemale
	| events |
	events _ self eventsFromString: self aliceExampleString.
	events do: [ :each | each pitchBy: 1.3].
	^ events