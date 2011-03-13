request: prompt initialAnswer: initialAnswer
	| answer |
	FillInTheBlank
		request: prompt
		displayAt: Sensor cursorPoint
		centered: true
		action: [:a | answer _ a] 
		initialAnswer: initialAnswer.
	^ answer
