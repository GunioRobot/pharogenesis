initialize
	"initialize the state of the receiver"
	super initialize.
	""
	damageReported _ false.
	self extent: 400 @ 250.

	infectionHistory _ OrderedCollection new.
	transmitInfection _ false.
	self addAtoms: 30