compileSingleFieldMethod: selString type: typeString
	| source |
	source := String streamContents:[:s|
		s nextPutAll: selString.
		s nextPutAll:' aVRMLStream'.
		s crtab.
		s nextPutAll:'"This method was automatically generated"'.
		s crtab.
		s nextPutAll:'^aVRMLStream read'.
		s nextPutAll: typeString.
	].
	self compile: source classified:'single field parsing'