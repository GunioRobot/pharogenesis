relatedPlayer
	(morph isMemberOf: MovieFrameSyncMorph)
		ifFalse: [^ nil].
	^ morph moviePlayerMorph