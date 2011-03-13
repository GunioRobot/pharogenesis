initialize: maxLevel
	pointers := Array new: maxLevel.
	splice := Array new: maxLevel.
	numElements := 0.
	level := 0.
	Rand ifNil: [Rand := Random new]