shiftedYellowButtonMessages
	^ (model respondsTo: #shiftedYellowButtonMessages)
		ifTrue:
			[model shiftedYellowButtonMessages]
		ifFalse:
			[super shiftedYellowButtonMessages]