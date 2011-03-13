withAnswersDo: aBlock

	(aBlock respondsTo: #valueSuppressingMessages:supplyingAnswers: )
		ifTrue: [aBlock valueSuppressingMessages: self messagesToSuppress supplyingAnswers: self answers.]
		ifFalse: [ aBlock value ]
