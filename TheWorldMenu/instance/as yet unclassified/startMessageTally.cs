startMessageTally

	(self confirm: 'MessageTally will start now,
and stop when the cursor goes
to the top of the screen') ifTrue:
		[MessageTally spyOn:
			[[Sensor primMousePt y > 0] whileTrue: [Display doOneCycleMorphic]]]