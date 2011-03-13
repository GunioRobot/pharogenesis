accept
	"Inform the model of text to be accepted, and return true if OK."
	| textToAccept oldSelector |
	oldSelector _ functionSelector.
	textToAccept _ textMorph asText.
	textToAccept = self getText ifTrue: [^ self].  "No body to compile yet"
	functionSelector _ model class
		compile: self headerString , textToAccept asString
		classified: 'functions' notifying: nil.
	self setText: textToAccept.
	self hasUnacceptedEdits: false.
	oldSelector ifNotNil:
		[functionSelector = oldSelector ifFalse: [model class removeSelector: oldSelector]].
	self fire