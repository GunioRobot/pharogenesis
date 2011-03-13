zapDefaultOnlyEntries

	| lastIndex newInst |
	1 to: self basicSize do: [:i |
		(self allDefaultValueSubtableAt: i) ifTrue: [self basicAt: i put: nil].
	].

	lastIndex _ self findLastNonNilSubTable.
	lastIndex = 0 ifTrue: [^ self].
	
	newInst _ self class new: lastIndex*chunkSize chunkSize: chunkSize arrayClass: (self basicAt: lastIndex) class base: base defaultValue: defaultValue.
	newInst privateSize: self size.
	base to: newInst size do: [:i | newInst at: i put: (self at: i)].
	1 to: newInst basicSize do: [:i |
		(newInst allDefaultValueSubtableAt: i) ifTrue: [newInst basicAt: i put: nil].
	].

	" this is not allowed in production: self becomeForward: newInst. "
	^ newInst.
