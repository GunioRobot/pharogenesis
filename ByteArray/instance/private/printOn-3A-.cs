printOn: aStream 
	"Refer to the comment in Object|printOn:."

	| tooMany |
	tooMany _ aStream position + self maxPrint.
	aStream nextPutAll: self class name, ' ('.
	self do: 
		[:element | 
		aStream position > tooMany ifTrue: [aStream nextPutAll: '...etc...)'. ^self].
		element asCharacter printOn: aStream.
		aStream space].
	aStream nextPut: $)