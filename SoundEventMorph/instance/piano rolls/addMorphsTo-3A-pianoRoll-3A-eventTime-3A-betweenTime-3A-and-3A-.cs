addMorphsTo: morphList pianoRoll: pianoRoll eventTime: t betweenTime: leftTime and: rightTime

	| startX lengthInTicks endX |

	startTimeInScore > rightTime ifTrue: [^ self].  
	lengthInTicks _ pianoRoll scorePlayer ticksForMSecs: sound duration * 1000.0.
	startTimeInScore + lengthInTicks < leftTime ifTrue: [^ self].
	startX _ pianoRoll xForTime: startTimeInScore.
	endX _ pianoRoll xForTime: startTimeInScore + lengthInTicks.
	morphList add: 
		(self left: startX; width: endX - startX).

