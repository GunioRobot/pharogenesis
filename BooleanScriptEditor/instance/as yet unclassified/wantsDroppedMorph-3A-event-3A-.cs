wantsDroppedMorph: aMorph event: evt
	((aMorph isKindOf: PhraseTileMorph) and:
		[submorphs size == 1]) ifTrue: [^ false].
	^ aMorph isTileLike and: [aMorph resultType ~~ #command]
