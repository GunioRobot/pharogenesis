accept
	"Inform the model of text to be accepted, and return true if OK."
	| textToAccept |
	self canDiscardEdits ifTrue: [^ self flash].
	setTextSelector == nil ifTrue: [^ self].
	textToAccept _ textMorph asText.
	model perform: setTextSelector
			with: (Compiler evaluate: textToAccept logged: false).
	self setText: textToAccept.
	self hasUnacceptedEdits: false