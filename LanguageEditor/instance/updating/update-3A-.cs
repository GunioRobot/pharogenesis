update: aSymbol 
	"Receive a change notice from an object of whom the receiver  
	is a dependent."
	super update: aSymbol.
	""
	aSymbol == #untranslated
		ifTrue: [self refreshUntranslated].
	aSymbol == #translations
		ifTrue: [self refreshTranslations]