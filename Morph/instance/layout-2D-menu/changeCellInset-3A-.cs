changeCellInset: evt
	| handle |
	handle _ HandleMorph new forEachPointDo:[:newPoint |
		self cellInset: (newPoint - evt cursorPoint) asIntegerPoint // 5].
	evt hand attachMorph: handle.
	handle startStepping.
