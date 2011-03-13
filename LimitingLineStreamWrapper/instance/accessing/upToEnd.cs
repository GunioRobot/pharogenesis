upToEnd

	| ln |
	^String streamContents: [:strm |
		[(ln := self nextLine) isNil] whileFalse: [ 
			strm nextPutAll: ln; cr]]