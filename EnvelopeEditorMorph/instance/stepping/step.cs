step
	| mouseDown |
	playRemaining > 0 ifTrue:
		[playRemaining _ playRemaining - self stepTime max: 0.
		^ self].
	mouseDown _ self world hands first lastEvent redButtonPressed.
	(mouseDown and: [playMode = #duringEdits]) ifTrue:
		[self playSample].
	mouseDown not & prevMouseDown ifTrue:
		["Mouse just went up"
		playMode = #afterEdits ifTrue: [self playSample].
		limitXs = (limits collect: [:i | (envelope points at: i) x]) ifFalse:
			["Redisplay after changing limits"
			self editEnvelope: envelope]].
	prevMouseDown _ mouseDown