aliceShortExample
	| events |
	events _ self eventsFromString: self aliceShortExampleString.
	events do: [ :each | each pitchBy: 1.3].
	^ events