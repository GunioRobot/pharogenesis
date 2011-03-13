readDocumentAtStartup
	^ self
		valueOfFlag: #readDocumentAtStartup
		ifAbsent: [true]