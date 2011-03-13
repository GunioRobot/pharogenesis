setProperty: propName toValue: aValue

	aValue ifNil: [^ self removeProperty: propName].
	self assuredPropertyDictionary at: propName put: aValue.
