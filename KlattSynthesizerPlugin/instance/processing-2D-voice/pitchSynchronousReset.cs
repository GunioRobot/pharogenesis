pitchSynchronousReset
	self returnTypeC: 'void'.
	(frame at: F0) > 0
		ifTrue: [self voicedPitchSynchronousReset.
				periodCount _ periodCount + 1 \\ 65535]
		ifFalse: [t0 _ 1.
				nmod _ t0]