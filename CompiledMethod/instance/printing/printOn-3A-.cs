printOn: aStream 
	"Overrides method inherited from the byte arrayed collection."

	self printNameOn: aStream.
	aStream space; nextPutAll: self identityHashPrintString