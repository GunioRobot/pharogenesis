setGridding
	gridOn ifTrue: [^ gridOn _ false].
	FillInTheBlank request: 'Change grid or confirm...' 
		displayAt: Sensor cursorPoint centered: true
		action: [:answer | grid _ Compiler evaluate: answer] 
		initialAnswer: grid printString.
	gridOn _ true