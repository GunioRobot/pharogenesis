methodString

	| s |
	s _ WriteStream on: ''.
	s nextPutAll: scriptName; cr; cr; tab.
	s nextPutAll: self codeString.
	^ s contents
