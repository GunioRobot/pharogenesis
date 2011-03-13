connectedPins
	^ wires collect: [:w | w otherPinFrom: self]