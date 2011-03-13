clearDescriptions
"
	self clearDescriptions
"

	TTCDescriptions _ Set new.
	TTCDefault ifNotNil: [TTCDescriptions add: TTCDefault].
