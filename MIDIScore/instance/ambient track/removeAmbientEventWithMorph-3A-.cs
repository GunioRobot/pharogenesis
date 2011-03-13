removeAmbientEventWithMorph: aMorph
	| i |
	i _ ambientTrack findFirst: [:e | e morph == aMorph].
	i = 0 ifTrue: [^ self].
	ambientTrack _ ambientTrack copyReplaceFrom: i to: i with: Array new