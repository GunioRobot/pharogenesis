removeProperty: propName
	properties ifNil: [^ self].
	properties removeKey: propName ifAbsent: [].
	properties size == 0 ifTrue: [properties _ nil]