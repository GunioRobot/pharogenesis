temporary: offset
	self assertIsLegalTempOffset: offset.
	^ self longAt: self temporaryPointer"localTP" + (offset * 4)