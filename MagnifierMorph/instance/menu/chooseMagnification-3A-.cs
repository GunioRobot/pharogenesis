chooseMagnification: evt
	| handle origin aHand currentMag |
	currentMag _ magnification.
	aHand _ evt ifNil: [self currentHand] ifNotNil: [evt hand].
	origin _ aHand position y.
	handle _ HandleMorph new forEachPointDo:
		[:newPoint | self magnification: (newPoint y - origin) / 8.0 + currentMag].
	aHand attachMorph: handle.
	handle startStepping.
	self changed. "Magnify handle"