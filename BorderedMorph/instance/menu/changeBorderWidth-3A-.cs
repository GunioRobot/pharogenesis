changeBorderWidth: evt
	| handle origin aHand |
	aHand _ evt ifNil: [self primaryHand] ifNotNil: [evt hand].
	origin _ aHand gridPointRaw.
	handle _ HandleMorph new forEachPointDo:
		[:newPoint | handle removeAllMorphs.
		handle addMorph:
			(PolygonMorph vertices: (Array with: origin with: newPoint)
				color: Color black borderWidth: 1 borderColor: Color black).
		self borderWidth: (newPoint - origin) r asInteger // 5].
	aHand attachMorph: handle.
	handle startStepping