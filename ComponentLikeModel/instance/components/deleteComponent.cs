deleteComponent
	model removeDependent: self.
	self pinsDo: [:pin | pin delete].
	^ super delete