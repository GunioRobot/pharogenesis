setCurveBaseline: evt
	| handle origin |
	origin _ evt cursorPoint.
	handle _ HandleMorph new forEachPointDo:
		[:newPoint | handle removeAllMorphs.
		handle addMorph:
			(PolygonMorph vertices: (Array with: origin with: newPoint)
				color: Color black borderWidth: 1 borderColor: Color black).
		container baseline: (newPoint - origin) y negated asInteger // 5.
		self paragraph composeAll].
	evt hand attachMorph: handle.
	handle startStepping	