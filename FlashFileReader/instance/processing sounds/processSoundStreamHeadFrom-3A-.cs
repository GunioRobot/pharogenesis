processSoundStreamHeadFrom: data
	| mixFmt flags stereo bitsPerSample compressed sampleCount |
	mixFmt := data nextByte.
	flags := data nextByte.
	stereo := flags anyMask: 1.
	self flag: #wrongSpec.
	bitsPerSample := (flags anyMask: 2) ifTrue:[16] ifFalse:[8].
	compressed := (flags bitShift: -4) = 1.
	sampleCount := data nextWord.
	self recordSoundStreamHead: mixFmt stereo: stereo bitsPerSample: bitsPerSample sampleCount: sampleCount compressed: compressed.
	^true