setGridding

	| response |
	gridOn ifTrue: [^ gridOn _ false].
	response _
		FillInTheBlank
			request: 'Change grid or confirm...'
			initialAnswer: grid printString.
	response isEmpty ifTrue: [^ self].
	grid _ Compiler evaluate: response.
	gridOn _ true.
