wantsDroppedMorph: aMorph event: evt

	^ (aMorph isTileLike and: [aMorph resultType == #command]) and:
		[self isTextuallyCoded not]
