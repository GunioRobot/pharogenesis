addAmbientEvent: evt
	| i |
	i _ ambientTrack findFirst: [:e | e time >= evt time].
	i = 0 ifTrue: [^ ambientTrack _ ambientTrack , (Array with: evt)].
	ambientTrack _ ambientTrack copyReplaceFrom: i to: i-1 with: (Array with: evt)