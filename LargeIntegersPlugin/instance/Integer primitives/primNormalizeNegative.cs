primNormalizeNegative
	""
	| rcvr |
	self debugCode: [self msg: 'primNormalizeNegative'].
	rcvr _ self
				primitive: 'primNormalizeNegative'
				parameters: #()
				receiver: #LargeNegativeInteger.
	^ self normalizeNegative: rcvr