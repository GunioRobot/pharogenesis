subscript: array with: index format: fmt
	"Note: This method assumes that the index is within bounds!"

	self inline: true.
	fmt <= 4 ifTrue: [  "pointer type objects"
		^ self fetchPointer: index - 1 ofObject: array].
	fmt < 8 ifTrue: [  "long-word type objects"
		^ self positive32BitIntegerFor:
			(self fetchWord: index - 1 ofObject: array)
	] ifFalse: [  "byte-type objects"
		^ self integerObjectOf:
			(self fetchByte: index - 1 ofObject: array)
	].