getLongFromFile: f swap: swapFlag
	"Return the next 4-byte word of the given file, byte-swapped according to the given flag."

	| w |
	self var: #f declareC: 'sqImageFile f'.
	self cCode: 'sqImageFileRead(&w, sizeof(char), 4, f)'.
	swapFlag
		ifTrue: [^ self byteSwapped: w]
		ifFalse: [^ w].
