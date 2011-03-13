shadowPoint: newPoint
	self changed.
	self shadowOffset: newPoint - self center // 5.
	fullBounds ifNotNil:[fullBounds _ self privateFullBounds].
	self changed.