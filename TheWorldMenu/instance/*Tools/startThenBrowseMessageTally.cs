startThenBrowseMessageTally
	(self confirm: 'MessageTally will start now,
and stop when the cursor goes
to the top of the screen')
		ifTrue: [TimeProfileBrowser
				onBlock: [[Sensor peekMousePt y > 10]
						whileTrue: [World doOneCycle]]]