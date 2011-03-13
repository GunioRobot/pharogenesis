step
	| nowStepTime maxSteps |
	playing ifFalse:[^self].
	self useTimeSync ifTrue:[
		maxSteps := 5.
		nowStepTime := Time millisecondClockValue.
		[(lastStepTime + stepTime <= nowStepTime) and:[playing and:[maxSteps >= 0]]]
			whileTrue:[
				self stepForward.
				lastStepTime := lastStepTime + stepTime.
				maxSteps := maxSteps - 1.
			].
	] ifFalse:[self stepForward].
	damageRecorder := nil. "Insurance"