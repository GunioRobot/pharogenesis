correctFrom: start to: stop with: aString
	
	view ifNotNil: [view correctFrom: start to: stop with: aString].
	^super correctFrom: start to: stop with: aString
