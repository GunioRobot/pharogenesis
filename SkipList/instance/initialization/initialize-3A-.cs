initialize: maxLevel
	pointers _ Array new: maxLevel.
	splice _ Array new: maxLevel.
	numElements _ 0.
	level _ 0.
	Rand ifNil: [Rand _ Random new]