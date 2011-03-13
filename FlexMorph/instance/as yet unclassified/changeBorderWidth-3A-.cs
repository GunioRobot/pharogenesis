changeBorderWidth: evt
	| handle origin aHand |
	aHand _ evt ifNil: [self primaryHand] ifNotNil: [evt hand].
	origin _ aHand position.
	handle _ HandleMorph new forEachPointDo:
		[:newPoint | handle removeAllMorphs.
		handle addMorph:
			(LineMorph from: origin to: newPoint color: Color black width: 1).
		self borderWidth: (newPoint - origin) r asInteger // 5].
	aHand attachMorph: handle.
	handle startStepping