compileSingleFieldMethod: selString type: typeString
	| source selParts |
	source := String streamContents:[:s|
		selParts := selString findTokens: ':'.
		s nextPutAll: (selParts at: 1).
		s nextPutAll: ': aField '.
		s nextPutAll: (selParts at: 2).
		s nextPutAll: ': aVRMLStream '.
		s nextPutAll: (selParts at: 3).
		s nextPutAll: ': level '.
		s crtab.
		s nextPutAll:'"This method was automatically generated"'.
		s crtab.
		s nextPutAll:'^aVRMLStream write'.
		s nextPutAll: typeString.
		s nextPutAll:': aField'.
	].
	self compile: source classified:'single field writing'