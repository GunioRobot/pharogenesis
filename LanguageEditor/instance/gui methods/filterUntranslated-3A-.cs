filterUntranslated: aString 
	| filter |
	filter := aString
				ifNil: [''].
	""
	untranslatedFilter := filter.
	self update: #untranslated