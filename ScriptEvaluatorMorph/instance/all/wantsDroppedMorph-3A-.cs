wantsDroppedMorph: aMorph
	true ifTrue: [^ false].  "for now anyway"
	^ aMorph isTileLike and: [aMorph resultType ~~ #command]