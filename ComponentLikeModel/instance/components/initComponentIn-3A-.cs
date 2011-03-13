initComponentIn: aLayout
	model _ aLayout model.
	self nameMeIn: aLayout.
	self color: Color lightCyan.
	self initPinSpecs.
	self initFromPinSpecs.
	self showPins.
	model addDependent: self