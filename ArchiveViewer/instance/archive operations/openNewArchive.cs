openNewArchive
	|  result |
	result := FileList2 modalFileSelector .
	result ifNil: [ ^self ].
	self fileName: (result directory fullNameFor: result name).
