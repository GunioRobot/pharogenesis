shadowPoint: newPoint
	self changed.
	shadowOffset _ newPoint - self center // 5.
	self changed