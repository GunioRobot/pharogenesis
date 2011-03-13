addMorphsTo: morphList pianoRoll: pianoRoll eventTime: t betweenTime: leftTime and: rightTime

	| startX myDurationInTicks endX |

	startX _ pianoRoll xForTime: t.
	myDurationInTicks _ pianoRoll scorePlayer ticksForMSecs: self myDurationInMS.
	t > rightTime ifTrue: [^ self].  
	(t + myDurationInTicks) < leftTime ifTrue: [^ self].
	endX _ pianoRoll xForTime: t + myDurationInTicks.

	morphList add: 
		(self hResizing: #spaceFill; left: startX; width: endX - startX).

