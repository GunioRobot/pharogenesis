selectFrom: selection

	(trackIndex = (selection at: 1)
		and: [indexInTrack >= (selection at: 2)
		and: [indexInTrack <= (selection at: 3)]])
		ifTrue: [selected ifFalse: [self select]]
		ifFalse: [selected ifTrue: [self deselect]]