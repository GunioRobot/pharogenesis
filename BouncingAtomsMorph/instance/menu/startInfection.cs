startInfection

	self submorphsDo: [:m | m infected: false].
	self firstSubmorph infected: true.
	infectionHistory _ OrderedCollection new: 500.
	transmitInfection _ true.
	self startStepping.
