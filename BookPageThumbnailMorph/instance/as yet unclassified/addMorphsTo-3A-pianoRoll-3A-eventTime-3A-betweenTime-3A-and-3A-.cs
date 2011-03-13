addMorphsTo: morphList pianoRoll: pianoRoll eventTime: t betweenTime: leftTime and: rightTime

	t > rightTime ifTrue: [^ self].  
	t < leftTime ifTrue: [^ self].

	morphList add: (self left: (pianoRoll xForTime: t)).
