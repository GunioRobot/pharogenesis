primNormalizePositive
	| rcvr |
	""
	self debugCode: [self msg: 'primNormalizePositive'].
	rcvr _ self
		primitive: 'primNormalizePositive'
		parameters: #()
		receiver: #LargePositiveInteger.
	^ self normalizePositive: rcvr