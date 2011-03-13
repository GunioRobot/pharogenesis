aliceShortExample
	| events |
	events := self eventsFromString: self aliceShortExampleString.
	events do: [ :each | each pitchBy: 1.3].
	^ events