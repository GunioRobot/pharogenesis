testStringConversionCrLF
	| string newString |
	string _ 'This is a test', String crlf, 'of the conversion'.
	newString _ string withSqueakLineEndings.
	self assert: ((string size - 1) = newString size).