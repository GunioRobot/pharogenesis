processDefineSound: data
	| flags sampleCount sampleData id stereo bitsPerSample rate compressed sound |
	id _ data nextWord.
	flags _ data nextByte.
	stereo _ (flags anyMask: 1).
	bitsPerSample _ (flags anyMask: 2) ifTrue:[16] ifFalse:[8].
	rate _ #( 5512 11025 22050 44100 ) at: (flags >> 2 bitAnd: 3)+1.
	compressed _ flags anyMask: 16.
	sampleCount _ data nextULong.
	sampleData _ data upToEnd.
	compressed ifTrue:[
		self isStreaming ifFalse:[Cursor wait show].
		sound _ self decompressSound: sampleData 
						stereo: stereo 
						samples: sampleCount 
						rate: rate.
		self isStreaming ifFalse:[Cursor normal show].
	] ifFalse:[
		self halt.
		sound _ nil.
	].
	self recordSound: id data: sound.
	^true