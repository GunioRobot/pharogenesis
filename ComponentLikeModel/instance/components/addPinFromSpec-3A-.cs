addPinFromSpec: pinSpec
	| pin |
	pin _ PinMorph new component: self pinSpec: pinSpec.
	self addMorph: pin.
	pin placeFromSpec.
	^ pin