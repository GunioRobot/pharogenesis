setProperty: propName toValue: aValue

	aValue ifNil: [^ self removeProperty: propName].
	self properties at: propName put: aValue.