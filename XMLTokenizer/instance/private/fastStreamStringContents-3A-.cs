fastStreamStringContents: writeStream
	| newSize |
	newSize _ writeStream position.
	^(String new: newSize)
		replaceFrom: 1
		to: newSize
		with: writeStream originalContents
		startingAt: 1