startThenBrowseMessageTally
	(self confirm: 'MessageTally will start now,
and stop when the cursor goes
to the top of the screen')
		ifTrue: [TimeProfileBrowser
				onBlock: [[Sensor primMousePt y > 10]
						whileTrue: [Display doOneCycleMorphic]]]