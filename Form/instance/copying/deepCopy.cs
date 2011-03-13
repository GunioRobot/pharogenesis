deepCopy
	| newForm |
	newForm _ self shallowCopy.
	newForm bits: (bits class new: self bitsSize).
	newForm copyBits: self boundingBox
		from: self
		at: 0 @ 0
		clippingBox: newForm boundingBox
		rule: Form over
		fillColor: nil.
	^newForm