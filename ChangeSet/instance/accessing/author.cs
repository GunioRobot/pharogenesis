author
	| author |
	self assurePreambleExists.
	author _ self preambleString lineNumber: 3.
	author _ author copyFrom: 8 to: author size. "Strip the 'Author:' prefix. Ugly ugly."	
	^author withBlanksTrimmed.
	