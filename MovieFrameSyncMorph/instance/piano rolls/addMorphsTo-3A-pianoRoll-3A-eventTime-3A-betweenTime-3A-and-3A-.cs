addMorphsTo: morphList pianoRoll: pianoRoll eventTime: t betweenTime: leftTime and: rightTime

	| leftX |
	t > rightTime ifTrue: [^ self  "Start time has not come into view."].  
	leftX := pianoRoll xForTime: t.
	(leftX + self width) < pianoRoll left ifTrue: [^ self  "End time has passed out of view."].
	morphList add: 
		(self align: self bottomLeft
			with: leftX @ (pianoRoll bottom - pianoRoll borderWidth)).
