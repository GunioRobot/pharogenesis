aliceShortExampleMale
	| events |
	events _ self eventsFromString: self aliceShortExampleString.
	events do: [ :each | each pitchBy: 0.4].
	^ events