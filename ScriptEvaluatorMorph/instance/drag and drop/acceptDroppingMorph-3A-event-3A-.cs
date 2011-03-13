acceptDroppingMorph: aMorph event: evt
	(aMorph isKindOf: PhraseTileMorph) ifTrue: [^ self].
	^ super acceptDroppingMorph: aMorph event: evt