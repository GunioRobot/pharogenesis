testSimpleTextConversionCrLF
	| string newText |
	string _ 'This is a test', String crlf, 'of the conversion'.
	newText _ string asText withSqueakLineEndings.
	self assert: ((string size - 1) = newText size).
	self assert: (newText size = newText runs size).