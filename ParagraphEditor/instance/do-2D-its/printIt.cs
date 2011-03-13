printIt
	"Treat the current text selection as an expression; evaluate it. Insert the 
	description of the result of evaluation after the selection and then make 
	this description the new text selection."
	| result |
	result _ self evaluateSelection.
	((result isKindOf: FakeClassPool) or: [result == #failedDoit])
			ifTrue: [view flash]
			ifFalse: [self afterSelectionInsertAndSelect: result printString]