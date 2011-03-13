step
	| nowStepTime maxSteps |
	playing ifFalse:[^self].
	self useTimeSync ifTrue:[
		maxSteps _ 5.
		nowStepTime _ Time millisecondClockValue.
		[(lastStepTime + stepTime <= nowStepTime) and:[playing and:[maxSteps >= 0]]]
			whileTrue:[
				self stepForward.
				lastStepTime _ lastStepTime + stepTime.
				maxSteps _ maxSteps - 1.
			].
	] ifFalse:[self stepForward].
	damageRecorder _ nil. "Insurance"