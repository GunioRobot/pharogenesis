startMessageTally

	(self confirm: 'MessageTally will start now,
and stop when the cursor goes
to the top of the screen') ifTrue:
		[MessageTally spyAllOn:
			[[Sensor peekMousePt y > 0] whileTrue: [World doOneCycle]]]