changeBorderWidth: evt
	| handle origin |
	origin _ evt hand gridPointRaw.
	handle _ HandleMorph new forEachPointDo:
		[:newPoint | handle removeAllMorphs.
		handle addMorph:
			(PolygonMorph vertices: (Array with: origin with: newPoint)
				color: Color black borderWidth: 1 borderColor: Color black).
		self borderWidth: (newPoint - origin) r asInteger // 5].
	evt hand attachMorph: handle.
	handle startStepping