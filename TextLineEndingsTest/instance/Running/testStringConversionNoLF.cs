testStringConversionNoLF
	| string newString |
	string _ 'This is a test', String cr, 'of the conversion'.
	newString _ string withSqueakLineEndings.
	self assert: (string = newString).