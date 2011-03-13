processSoundInfoFrom: data
	| flags info nPoints |
	flags := data nextByte.
	info := FlashSoundInformation new.
	info syncFlags: (flags bitShift: -4).
	(flags anyMask: 1) ifTrue:[info inPoint: data nextULong].
	(flags anyMask: 2) ifTrue:[info outPoint: data nextULong].
	(flags anyMask: 4) ifTrue:[info loopCount: data nextWord].
	(flags anyMask: 8) ifTrue:[
		nPoints := data nextByte.
		info envelopes: ((1 to: nPoints) collect:[:i| self processEnvelopeFrom: data]).
	].
	^info