stopSoundTrackIfAny

	scorePlayer == nil ifTrue:[^ self].
	(scorePlayer isKindOf: SampledSound)
		ifTrue: [scorePlayer endGracefully]
		ifFalse: [scorePlayer _ nil]