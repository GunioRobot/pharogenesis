removeProperty: propName
	self valueOfProperty: propName ifAbsent:[^self].
	self properties removeKey: propName.