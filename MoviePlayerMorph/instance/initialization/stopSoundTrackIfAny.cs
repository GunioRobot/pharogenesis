stopSoundTrackIfAny

	scorePlayer == nil ifTrue:[^ self].
	(scorePlayer isKindOf: SampledSound)
		ifTrue: [scorePlayer pause]
		ifFalse: [scorePlayer _ nil]