checkAddress: byteAddress 
	"Keep this method around for debugging the C code."
	byteAddress < self startOfMemory
		ifTrue: [self error: 'bad address: negative'].
	byteAddress >= memoryLimit
		ifTrue: [self error: 'bad address: past end of heap']