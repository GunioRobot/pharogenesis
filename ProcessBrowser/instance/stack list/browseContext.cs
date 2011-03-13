browseContext
	selectedContext
		ifNil: [^ self].
	Browser newOnClass: self selectedClass selector: self selectedSelector