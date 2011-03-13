copy
	self error: 'should not be called'.
	^super copy
		transformations: (self transformations collect: [:each | each copy]);
		yourself