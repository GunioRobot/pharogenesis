resizeMorph: evt
	| handle |
	handle _ HandleMorph new forEachPointDo: [:newPoint | 
		self extent: (self griddedPoint: newPoint) - self bounds topLeft].
	evt hand attachMorph: handle.
	handle startStepping.
