accept
	"Inform the model of text to be accepted, and return true if OK."
	| textToAccept ok |
	self canDiscardEdits ifTrue: [^ self flash].
	textToAccept _ textMorph asText.
	ok _ (setTextSelector == nil) or:
		[setTextSelector numArgs = 2
			ifTrue: [model perform: setTextSelector with: textToAccept with: self]
			ifFalse: [model perform: setTextSelector with: textToAccept]].
	ok ifTrue:
		[self setText: self getText.
		self hasUnacceptedEdits: false]