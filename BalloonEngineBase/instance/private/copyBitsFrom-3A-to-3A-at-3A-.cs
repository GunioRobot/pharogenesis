copyBitsFrom: x0 to: x1 at: yValue
	copyBitsFn = 0 ifTrue:[
		"We need copyBits here so try to load it implicitly"
		self initialiseModule ifFalse:[^false].
	].
	^self cCode:' ((int (*) (int, int, int)) copyBitsFn)(x0, x1, yValue)'