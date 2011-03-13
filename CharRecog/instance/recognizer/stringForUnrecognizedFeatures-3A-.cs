stringForUnrecognizedFeatures: features
	"Prompt the user for what string the current features represent, and return the result.  9/18/96 sw"

	| result |
	result _ FillInTheBlank request:
('Not recognized. type char, or "tab", "cr" or "bs",
or hit return to ignore 
', features).

	^ (result = '~' | result = '')
		ifTrue:
			['']
		ifFalse:
			[CharacterDictionary at: features put: result. result]