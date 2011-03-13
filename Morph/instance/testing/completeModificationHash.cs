completeModificationHash

"World completeModificationHash"

	| resultSize result here i |
	resultSize _ 10.
	result _ ByteArray new: resultSize.
	self allMorphsDo: [ :each | 
		here _ each modificationHash.
		here withIndexDo: [ :ch :index |
			i _ index \\ resultSize + 1.
			result at: i put: ((result at: i) bitXor: ch asciiValue)
		].
	].
	^result