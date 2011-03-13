step
	"If appropriate update the receiver's label"

	| newString |
	super step.
	wordingProvider ifNotNil:
		[newString _ wordingProvider perform: wordingSelector.
		newString = self label ifFalse: [self labelString: newString; changed]]