compressRunArray: aShortRunArray
	stream nextPut:$+; print: aShortRunArray runSize.
	aShortRunArray lengthsAndValuesDo:[:runLength :runValue|
		runLength < 0 ifTrue:[self error:'Bad run length'].
		stream nextPut:$+; print: runLength.
		runValue < 0
			ifTrue:[stream print: runValue]
			ifFalse:[stream nextPut:$+; print: runValue].
	].
	stream nextPut:$X. "Terminator"
	^stream