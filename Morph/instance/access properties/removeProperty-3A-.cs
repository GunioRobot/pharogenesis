removeProperty: propName
	extension == nil ifTrue: [^ self].
	extension removeProperty: propName