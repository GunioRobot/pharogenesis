at: offset

	ptrOffset = 0 ifFalse: [self error: 'only expect base address to receive at: message'].
	unitSize = 1 ifTrue: [^ interpreter byteAt: arrayBaseAddress + offset].
	unitSize = 4 ifTrue: [^ interpreter longAt: arrayBaseAddress + (offset * 4)].
	self halt: 'Can''t handle unitSize ', unitSize printString
