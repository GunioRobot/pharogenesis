stopSoundTrackIfAny
	scorePlayer isNil ifTrue: [^self].
	(scorePlayer isKindOf: SampledSound) 
		ifTrue: [scorePlayer endGracefully]
		ifFalse: [scorePlayer := nil]