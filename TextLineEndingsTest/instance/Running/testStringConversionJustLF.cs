testStringConversionJustLF
	| string newString |
	string _ 'This is a test', String lf, 'of the conversion'.
	newString _ string withSqueakLineEndings.
	self assert: (string size = newString size).