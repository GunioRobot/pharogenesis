initComponentIn: aLayout
	model _ aLayout model.
	self nameMeIn: aLayout world.
	self color: Color lightCyan.
	self showPins.
	model addDependent: self