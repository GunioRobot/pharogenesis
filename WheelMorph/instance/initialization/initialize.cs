initialize
	super initialize.
	self target: nil.
	self actionSelector: #flash.
	self angle: 0.
	self maxAngle: 360.
	self factor: 1.0.
	self extent: 100@18.
	self beCircular.
	self borderColor: #raised.
	self borderWidth: 1.
	self color: Color lightGray.
	lastRedraw := 0.