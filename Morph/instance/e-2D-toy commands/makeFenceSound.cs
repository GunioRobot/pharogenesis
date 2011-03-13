makeFenceSound

	self world soundsEnabled ifTrue:
		[self playSoundNamed: 'scratch'].
