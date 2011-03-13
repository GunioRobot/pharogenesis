wantsDroppedMorph: aMorph

	^ (aMorph isTileLike and: [aMorph resultType == #command]) and:
		[self isTextuallyCoded not]
