processSoundStreamHeadFrom: data
	| mixFmt flags stereo bitsPerSample compressed sampleCount |
	mixFmt _ data nextByte.
	flags _ data nextByte.
	stereo _ flags anyMask: 1.
	self flag: #wrongSpec.
	bitsPerSample _ (flags anyMask: 2) ifTrue:[16] ifFalse:[8].
	compressed _ (flags bitShift: -4) = 1.
	sampleCount _ data nextWord.
	self recordSoundStreamHead: mixFmt stereo: stereo bitsPerSample: bitsPerSample sampleCount: sampleCount compressed: compressed.
	^true