printOn: aStream 
	"Overrides method inherited from the byte arrayed collection."

	self printNameOn: aStream.
	aStream nextPut: $(; print: self identityHash; nextPutAll: ': '; 
		print: self methodClass; nextPutAll: '>>'; nextPutAll: self selector; nextPut: $).
	"aStream space; nextPutAll: self identityHashPrintString"
