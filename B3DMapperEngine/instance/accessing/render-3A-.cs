render: anObject
	| oldBounds|
	oldBounds _ bounds.
	bounds _ nil.
	anObject renderOn: self.
	boundsMap at: anObject put: bounds.
	oldBounds == nil ifTrue:[^self].
	bounds == nil ifTrue:[^bounds _ oldBounds].
	oldBounds == nil ifTrue:[^bounds].
	bounds _ bounds quickMerge: oldBounds.
	^bounds