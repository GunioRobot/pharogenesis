setTreeDepth

	| reply |
	reply := UIManager default
		request: 'Tree depth (a number between 1 and 12)?'
		initialAnswer: depth printString.
	reply isEmpty ifTrue: [^ self].
	depth := ((reply asNumber rounded) max: 1) min: 12.
	self startOver.
