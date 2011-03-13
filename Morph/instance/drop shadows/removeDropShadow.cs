removeDropShadow
	self hasDropShadow ifFalse:[^self].
	self changed.
	self hasDropShadow: false.
	fullBounds ifNotNil:[fullBounds _ self privateFullBounds].
	self changed.