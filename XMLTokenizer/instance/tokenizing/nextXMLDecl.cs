nextXMLDecl
	| attributes nextChar namespaces |
	self skipSeparators.
	attributes _ Dictionary new.
	namespaces _ Dictionary new.
	[(nextChar _ self peek) == $?] whileFalse: [
		self nextAttributeInto: attributes namespaces: namespaces.
		self skipSeparators.].
	self next.
	self next == $>
		ifFalse: [self errorExpected: '> expected.'].
	self handleXMLDecl: attributes namespaces: namespaces