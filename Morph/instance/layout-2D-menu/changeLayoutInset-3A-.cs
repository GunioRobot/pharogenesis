changeLayoutInset: evt
	| handle |
	handle _ HandleMorph new forEachPointDo:[:newPoint |
		self layoutInset: (newPoint - evt cursorPoint) asIntegerPoint // 5].
	evt hand attachMorph: handle.
	handle startStepping.
