printOn: aStream
	| tooMany |
	tooMany _ self maxPrint.	
		"Need absolute limit, or infinite recursion will never 
		notice anything going wrong.  7/26/96 tk"
	aStream nextPutAll: self class name, ' ('.
	self associationsDo: 
		[:element | 
		aStream position > tooMany
			ifTrue: [aStream nextPutAll: '...etc...)'. ^ self].
		element printOn: aStream.
		aStream space].
	aStream nextPut: $)