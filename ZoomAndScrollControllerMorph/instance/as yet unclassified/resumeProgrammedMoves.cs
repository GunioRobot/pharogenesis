resumeProgrammedMoves

	| thisStep |

	programmedMoves isEmptyOrNil ifTrue: [^self].
	(thisStep _ programmedMoves first)
		at: #pauseTime
		ifPresent: [ :pauseTime |
			thisStep 
				at: #startTime 
				put: (thisStep at: #startTime) + Time millisecondClockValue - pauseTime.
			thisStep removeKey: #pauseTime ifAbsent: [].
		].
