addAmbientEvent: evt
	| i |
	ambientTrack == nil ifTrue: [^ ambientTrack _ Array with: evt].
	i _ ambientTrack findFirst: [:e | e time >= evt time].
	i = 0 ifTrue: [^ ambientTrack _ ambientTrack , (Array with: evt)].
	ambientTrack _ ambientTrack copyReplaceFrom: i to: i-1 with: (Array with: evt)