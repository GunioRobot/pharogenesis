accept
	"Inform the model of text to be accepted, and return true if OK."

	| textToAccept |
	self canDiscardEdits ifTrue: [^self flash].
	setTextSelector isNil ifTrue: [^self].
	textToAccept := textMorph asText.
	model perform: setTextSelector
		with: (Compiler evaluate: textToAccept logged: false).
	self setText: textToAccept.
	self hasUnacceptedEdits: false