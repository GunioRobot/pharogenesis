valueOfProperty: propName
	properties ifNil: [^ nil].
	^ properties at: propName ifAbsent: [nil]