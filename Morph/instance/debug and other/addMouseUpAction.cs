addMouseUpAction
	| codeToRun oldCode |
	oldCode := self
				valueOfProperty: #mouseUpCodeToRun
				ifAbsent: [''].
	codeToRun := FillInTheBlank request: 'MouseUp expression:' translated initialAnswer: oldCode.
	self addMouseUpActionWith: codeToRun