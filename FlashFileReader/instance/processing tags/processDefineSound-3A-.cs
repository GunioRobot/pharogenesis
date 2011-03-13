processDefineSound: data
	| flags sampleCount sampleData id stereo bitsPerSample rate compressed sound |
	id := data nextWord.
	flags := data nextByte.
	stereo := (flags anyMask: 1).
	bitsPerSample := (flags anyMask: 2) ifTrue:[16] ifFalse:[8].
	rate := #( 5512 11025 22050 44100 ) at: (flags >> 2 bitAnd: 3)+1.
	compressed := flags anyMask: 16.
	sampleCount := data nextULong.
	sampleData := data upToEnd.
	compressed ifTrue:[
		self isStreaming ifFalse:[Cursor wait show].
		sound := self decompressSound: sampleData 
						stereo: stereo 
						samples: sampleCount 
						rate: rate.
		self isStreaming ifFalse:[Cursor normal show].
	] ifFalse:[
		self halt.
		sound := nil.
	].
	self recordSound: id data: sound.
	^true