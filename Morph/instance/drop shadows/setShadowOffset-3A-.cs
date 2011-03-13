setShadowOffset: evt
	| handle |
	handle _ HandleMorph new forEachPointDo:
		[:newPoint | self shadowPoint: newPoint].
	evt hand attachMorph: handle.
	handle startStepping.
