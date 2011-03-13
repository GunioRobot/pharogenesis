step
	| mouseDown hand |
	playRemaining > 0 ifTrue:
		["Finish playing the last sample"
		playRemaining _ playRemaining - self stepTime max: 0.
		^ self].
	hand _ self world hands first.
	(bounds containsPoint: hand position) ifFalse: [^ self].

	mouseDown _ hand lastEvent redButtonPressed.
	(mouseDown and: [playMode = #duringEdits]) ifTrue:
		[self playSample].
	mouseDown not & prevMouseDown ifTrue:
		["Mouse just went up"
		playMode = #afterEdits ifTrue: [self playSample].
		limitXs = (limits collect: [:i | (envelope points at: i) x]) ifFalse:
			["Redisplay after changing limits"
			self editEnvelope: envelope]].
	prevMouseDown _ mouseDown