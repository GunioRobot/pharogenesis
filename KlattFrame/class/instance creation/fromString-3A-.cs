fromString: aString
	^ self fromArray: (aString substrings collect: [ :each | each asNumber])