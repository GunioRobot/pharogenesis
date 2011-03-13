wantsDroppedMorph: aMorph

	^ aMorph isTileLike and: [aMorph resultType ~~ #command]
