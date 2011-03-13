addMorphsTo: morphList pianoRoll: pianoRoll eventTime: t betweenTime: leftTime and: rightTime

	| startX pseudoEndTime |

	startX _ pianoRoll xForTime: startTimeInScore.
	pseudoEndTime _ pianoRoll timeForX: startX + self width.
	startTimeInScore > rightTime ifTrue: [^ self].  
	pseudoEndTime < leftTime ifTrue: [^ self].

	morphList add: 
		(self align: self bottomLeft
			with: startX @ self bottom).

