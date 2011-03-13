completeModificationHash

"World completeModificationHash"

	| resultSize result here i |
	resultSize := 10.
	result := ByteArray new: resultSize.
	self allMorphsDo: [ :each | 
		here := each modificationHash.
		here withIndexDo: [ :ch :index |
			i := index \\ resultSize + 1.
			result at: i put: ((result at: i) bitXor: ch asciiValue)
		].
	].
	^result