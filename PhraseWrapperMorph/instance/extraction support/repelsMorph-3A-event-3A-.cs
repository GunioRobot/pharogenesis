repelsMorph: aMorph event: ev
	^ (aMorph isKindOf: PhraseTileMorph) or:
		[aMorph hasProperty: #newPermanentScript]