initialize

	super initialize.
	damageReported _ false.
	self extent: 400@250.
	self color: (Color r: 0.8 g: 1.0 b: 0.8).
	infectionHistory _ OrderedCollection new.
	transmitInfection _ false.
 	self addAtoms: 30.
