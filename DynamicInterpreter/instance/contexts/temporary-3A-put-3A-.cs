temporary: offset put: aValue
	self assertIsLegalTempOffset: offset.
	^ self longAt: self temporaryPointer"localTP" + (offset * 4) put: aValue