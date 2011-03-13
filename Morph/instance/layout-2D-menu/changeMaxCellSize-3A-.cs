changeMaxCellSize: evt
	| handle |
	handle _ HandleMorph new forEachPointDo:[:newPoint |
		self maxCellSize: (newPoint - evt cursorPoint) asIntegerPoint].
	evt hand attachMorph: handle.
	handle startStepping.
