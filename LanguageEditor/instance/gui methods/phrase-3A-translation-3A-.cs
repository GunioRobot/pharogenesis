phrase: phraseString translation: translationString 
	"set the models's translation for phraseString"
	self translator phrase: phraseString translation: translationString.
	self changed: #translations.
	self changed: #untranslated.

	newerKeys add: phraseString.
