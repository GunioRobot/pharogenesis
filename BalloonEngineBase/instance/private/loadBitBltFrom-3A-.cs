loadBitBltFrom: bbObj
	loadBBFn = 0 ifTrue:[
		"We need copyBits here so try to load it implicitly"
		self initialiseModule ifFalse:[^false].
	].
	^self cCode: '((int (*) (int))loadBBFn)(bbObj)'