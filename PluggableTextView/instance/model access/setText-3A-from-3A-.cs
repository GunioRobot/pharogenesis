setText: textToAccept from: ctlr
	"Inform the model of text to be accepted, and return true if OK.
	Any errors should be reported to the controller, ctlr."
	setTextSelector == nil ifTrue: [^ true].
	setTextSelector numArgs = 2
		ifTrue: [^ model perform: setTextSelector with: textToAccept with: ctlr]
		ifFalse: [^ model perform: setTextSelector with: textToAccept]