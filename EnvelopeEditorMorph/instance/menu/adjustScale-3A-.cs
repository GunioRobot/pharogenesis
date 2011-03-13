adjustScale: evt
	| scaleString oldScale baseValue |
	oldScale _ envelope scale.
	scaleString _ FillInTheBlank request: 'Enter the new full-scale value...'
						initialAnswer: oldScale printString.
	scaleString isEmpty ifTrue: [^ self].
	envelope scale: (Number readFrom: scaleString) asFloat.
	baseValue _ envelope updateSelector = #pitch: ifTrue: [0.5] ifFalse: [0.0].
	envelope setPoints: (envelope points collect:
				[:p |
				p x @ (p y - baseValue * oldScale / envelope scale + baseValue
					min: 1.0 max: 0.0)])
			 loopStart: (limits at: 1) loopEnd: (limits at: 2).
	self buildView