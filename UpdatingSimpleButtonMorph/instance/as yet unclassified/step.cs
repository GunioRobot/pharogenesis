step
	| newString |
	super step.
	newString _ wordingProvider perform: wordingSelector.
	newString = self label ifFalse: [self labelString: newString; changed].