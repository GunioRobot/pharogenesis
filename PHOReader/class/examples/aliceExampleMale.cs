aliceExampleMale
	| events |
	events := self eventsFromString: self aliceExampleString.
	events do: [ :each | each pitchBy: 0.63489].
	^ events