upToEnd

	| ln |
	^String streamContents: [:strm |
		[(ln _ self nextLine) isNil] whileFalse: [ 
			strm nextPutAll: ln; cr]]