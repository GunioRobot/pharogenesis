updateLabel

	| label |
	(label _ self findA: StringMorph) ifNil: [^ self].
	label contents: (self controllerName: controller), ', ch: ', (channel + 1) printString.
