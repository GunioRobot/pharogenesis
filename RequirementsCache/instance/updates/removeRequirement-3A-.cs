removeRequirement: selector
	requirements ifNil: [^ self].
	requirements remove: selector ifAbsent: [].