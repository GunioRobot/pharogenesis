withAll: aCollection notIn: notCollection
	^ (self new: (self sizeFor: aCollection)) addAll: aCollection notIn: notCollection; yourself