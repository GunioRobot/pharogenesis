testSimpleTextConversionJustLF
	| string newText |
	string _ 'This is a test', String lf, 'of the conversion'.
	newText _ string asText withSqueakLineEndings.
	self assert: ((string size) = newText size).
	self assert: (newText size = newText runs size).