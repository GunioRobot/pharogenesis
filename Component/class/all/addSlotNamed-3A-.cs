addSlotNamed: aName
	(self allInstVarNames includes: aName) ifTrue: [self error: 'Duplicate slot name'].
	self addInstVarName: aName.
