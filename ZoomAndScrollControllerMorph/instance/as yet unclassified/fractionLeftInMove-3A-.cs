fractionLeftInMove: thisMove

	| steps stepsRemaining fractionLeft endTime startTime |

	(thisMove includesKey: #steps) ifTrue: [
		steps _ thisMove at: #steps ifAbsentPut: [1].
		stepsRemaining _ thisMove at: #stepsRemaining ifAbsentPut: [steps].
		stepsRemaining < 1 ifTrue: [^nil].
		stepsRemaining _ stepsRemaining - 1.
		fractionLeft _ stepsRemaining / steps. 
		thisMove at: #stepsRemaining put: stepsRemaining.
	] ifFalse: [
		endTime _ thisMove at: #endTime ifAbsent: [^nil].
		startTime _ thisMove at: #startTime ifAbsent: [^nil].
		fractionLeft _ (endTime - Time millisecondClockValue) / (endTime - startTime).
	].
	^fractionLeft max: 0
