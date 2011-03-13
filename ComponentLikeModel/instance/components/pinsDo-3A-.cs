pinsDo: pinBlock
	self submorphsDo: [:m | (m isKindOf: PinMorph) ifTrue: [pinBlock value: m]]