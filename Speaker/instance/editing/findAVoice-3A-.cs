findAVoice: aClass
	(self voice isKindOf: aClass) ifTrue: [^ self voice].
	(self voice isKindOf: CompositeVoice)
		ifTrue: [self voice do: [ :each | (each isKindOf: aClass) ifTrue: [^ each]]].
	^ nil