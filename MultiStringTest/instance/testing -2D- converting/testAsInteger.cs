testAsInteger
	self assert: '1796exportFixes-tkMX' asMultiString asInteger = 1796.
	self assert: 'donald' asMultiString asInteger isNil.
	self assert: 'abc234def567' asMultiString asInteger = 234.
	self assert: '-94' asMultiString asInteger = -94.
	self assert: 'foo-bar-92' asMultiString asInteger = -92.

	self assert: '1796exportFixes-tkMX' asMultiString asSignedInteger = 1796.
	self assert: 'donald' asMultiString asSignedInteger isNil.
	self assert: 'abc234def567' asMultiString asSignedInteger = 234.
	self assert: '-94' asMultiString asSignedInteger = -94.
	self assert: 'foo-bar-92' asMultiString asSignedInteger = -92.

	self assert: '1796exportFixes-tkMX' asMultiString asUnsignedInteger = 1796.
	self assert: 'donald' asMultiString asUnsignedInteger isNil.
	self assert: 'abc234def567' asMultiString asUnsignedInteger = 234.
	self assert: '-94' asMultiString asUnsignedInteger = 94.
	self assert: 'foo-bar-92' asMultiString asUnsignedInteger = 92