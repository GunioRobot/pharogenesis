setProperty: propName toValue: aValue

	aValue ifNil: [^ self removeProperty: propName].
	extension == nil ifTrue: [self assureExtension].
	extension setProperty: propName toValue: aValue