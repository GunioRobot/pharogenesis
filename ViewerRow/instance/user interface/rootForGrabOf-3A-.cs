rootForGrabOf: aMorph
	(aMorph isKindOf: PhraseTileMorph) ifFalse: [^ nil].
	^ (aMorph fullCopy isPartsDonor: false) position: aMorph positionInWorld